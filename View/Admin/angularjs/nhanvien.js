var app = angular.module('myappnhanvien', []).constant('api', 'http://localhost:18058/api/NhanVien/');
app.controller('mycontrollernhanvien', ['$scope', '$http', 'api', mycontroller]);

function mycontroller($scope, $http, api) {
    $http({
        method: "GET",
        url: api,
    }).then(function (res) {
        $scope.nhanviens = res.data;
        console.log(res.data);
    });
    $scope.reloadData = function () {
        $http({
            method: "GET",
            url: api,
        }).then(function (res) {
            $scope.nhanviens = res.data;

        });
    }
    $scope.showModal = function (id) {
        $scope.id = id;
        if (id == 0) {
            $scope.modalTitle = "Thêm mới thông tin nhân viên";
            if ($scope.nhanvien) {
                delete $scope.nhanvien;
            }
        } else {
            $scope.modalTitle = "Chỉnh sửa thông tin nhân viên";
            $http({
                method: "GET",
                url: api + id,
            }).then(function (res) {
                $scope.nhanvien = res.data[0];

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
                data: $scope.nhanvien,
                'content-Type': 'application/json'
            }).then(function (res) {
                $scope.nhanvien = res.data;
                location.reload();
            });
        } else {
            $http({
                method: "PUT",
                url:  api,
                data: $scope.nhanvien,
                'content-Type': 'application/json'
            }).then(function (res) {
                $scope.nhanvien = res.data;
                location.reload();
            });
        }
        $('#modelId').modal('hide');

    }
    $scope.deleteClick = function (id) {
        var hoi = confirm("Ban có muốn xóa thông tin nhân viên này không");
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