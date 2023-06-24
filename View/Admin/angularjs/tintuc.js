var app = angular.module('myapp', []).constant('api', 'http://localhost:18058/api/TinTuc/');
app.controller('tintucController', ['$scope', '$http', 'api', mycontroller]);

function mycontroller($scope, $http, api) {
    $http({
        method: "GET",
        url: api,
    }).then(function (res) {
        $scope.tintucs = res.data;
        console.log(res.data);
    });
    $scope.reloadData = function () {
        $http({
            method: "GET",
            url: api,
        }).then(function (res) {
            $scope.tintucs = res.data;

        });
    }
    $scope.showModal = function (id) {
        $scope.id = id;
        if (id == 0) {
            $scope.modalTitle = "Thêm mới tin tức";
            if ($scope.tintuc) {
                delete $scope.tintuc;
            }
        } else {
            $scope.modalTitle = "Sửa thông tin bài viết";
            $http({
                method: "GET",
                url: api + id,
            }).then(function (res) {
                $scope.tintuc = res.data[0];

                console.log(res.data);
            });
        }
        $('#modelId').modal('show');
    }
    $scope.saveData = function () {
        if ($scope.id == 0) {
            $http({
                method: "POST",
                url: api,
                data: $scope.tintuc,
                'content-Type': 'application/json'
            }).then(function (res) {
                $scope.tintuc = res.data;
                location.reload();
            });
        } else {
            $http({
                method: "PUT",
                url: api + $scope.id,
                data: $scope.tintuc,
                'content-Type': 'application/json'
            }).then(function (res) {
                $scope.tintuc = res.data;
                location.reload();
            });
        }
        $('#modelId').modal('hide');

    }
    $scope.deleteClick = function (id) {
        var hoi = confirm("Bạn có muốn xóa tin tức này không ?");
        if (hoi) {
            $http({
                method: "DELETE",
                url: api + id,
            }).then(function (res) {
                $scope.messave = res.data;
                $scope.reloadData();
            });
        }

    }
}