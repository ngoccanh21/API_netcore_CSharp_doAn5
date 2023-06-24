var app = angular.module('myapp', []).constant('api', 'http://localhost:18058/api/LoaiSanPham/');
app.controller('loaisanphamController', ['$scope', '$http', 'api', mycontroller]);

function mycontroller($scope, $http, api) {
    $http({
        method: "GET",
        url: api,
    }).then(function (res) {
        $scope.loaisanphams = res.data;
        console.log(res.data);
    });
    $scope.reloadData = function () {
        $http({
            method: "GET",
            url: api,
        }).then(function (res) {
            $scope.loaisanphams = res.data;

        });
    }
    $scope.showModal = function (id) {
        $scope.id = id;
        if (id == 0) {
            $scope.modalTitle = "Thêm mới loại sản phẩm";
            if ($scope.loaisanpham) {
                delete $scope.loaisanpham;
            }
        } else {
            $scope.modalTitle = "Sửa thông tin lọai sản phẩm";
            $http({
                method: "GET",
                url: api + id,
            }).then(function (res) {
                $scope.loaisanpham = res.data[0];

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
                data: $scope.loaisanpham,
                'content-Type': 'application/json'
            }).then(function (res) {
                $scope.loaisanpham = res.data;
                location.reload();
            });
        } else {
            $http({
                method: "PUT",
                url: api + $scope.id,
                data: $scope.loaisanpham,
                'content-Type': 'application/json'
            }).then(function (res) {
                $scope.loaisanpham = res.data;
                location.reload();
            });
        }
        $('#modelId').modal('hide');

    }
    $scope.deleteClick = function (id) {
        var hoi = confirm("Ban co muon xoa loai san pham nay khong?");
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