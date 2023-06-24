var app = angular.module('myapp', []).constant('api', 'http://localhost:18058/api/KhachHang/');
app.controller('khachhangController', ['$scope', '$http', 'api', mycontroller]);

function mycontroller($scope, $http, api) {
    $http({
        method: "GET",
        url: api,
    }).then(function (res) {
        $scope.khachhangs = res.data;
        console.log(res.data);
    });
    $scope.reloadData = function () {
        $http({
            method: "GET",
            url: api,
        }).then(function (res) {
            $scope.khachhangs = res.data;

        });
    }
    $scope.showModal = function (id) {
        $scope.id = id;
        if (id == 0) {
            $scope.modalTitle = "Thêm mới thông tin khách hàng";
            if ($scope.khachhang) {
                delete $scope.khachhang;
            }
        } else {
            $scope.modalTitle = "Sửa thông tin khách hàng";
            $http({
                method: "GET",
                url: api + id,
            }).then(function (res) {
                $scope.khachhang = res.data[0];

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
                data: $scope.khachhang,
                'content-Type': 'application/json'
            }).then(function (res) {
                $scope.khachhang = res.data;
                location.reload();
            });
        } else {
            $http({
                method: "PUT",
                url: api + $scope.id,
                data: $scope.khachhang,
                'content-Type': 'application/json'
            }).then(function (res) {
                $scope.khachhang = res.data;
                location.reload();
            });
        }
        $('#modelId').modal('hide');

    }
    $scope.deleteClick = function (id) {
        var hoi = confirm("Ban co muốn xóa thông tin khách hàng nay khong?");
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