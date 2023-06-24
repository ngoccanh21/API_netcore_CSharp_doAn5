var app = angular.module('myappsanpham', []).constant('api', 'http://localhost:18058/api/SanPham/');
app.directive("fileread", [function () {
    return {
        scope: {
            fileread: "="
        },
        link: function (scope, element, attributes) {
            element.bind("change", function (changeEvent) {
                var reader = new FileReader();
                reader.onload = function (loadEvent) {
                    scope.$apply(function () {
                        scope.fileread = loadEvent.target.result;
                    });
                }
                reader.readAsDataURL(changeEvent.target.files[0]);
            });
        }
    }
}]);

app.controller('sanphamController', ['$scope', '$http', 'api', mycontroller]);


function mycontroller($scope, $http, api) {
    $http({
        method: "GET",
        url: api,
    }).then(function (res) {
        $scope.sanphams = res.data;
        console.log(res.data);
    });
    $scope.reloadData = function () {
        $http({
            method: "GET",
            url: api,
        }).then(function (res) {
            $scope.sanphams = res.data;

        });
    }
    $scope.showModal = function (id) {
        $scope.id = id;
        if (id == 0) {
            $scope.modalTitle = "Tạo mới thông tin sản phẩm";
            if ($scope.sanpham) {
                delete $scope.sanpham;
            }
        } else {
            $scope.modalTitle = "Sửa thông tin sản phẩm";
            $http({
                method: "GET",
                url: api + id,
            }).then(function (res) {
                $scope.sanpham = res.data[0];

                console.log(res.data);
            });
        }
        $('#modelId').modal('show');
    }
    // function LayTTLoaiSP() {
    //     $http({
    //         method: "GET",
    //         url: 'http://localhost:18058/api/LoaiSanPham/',
    //     }).then(function (res) {
    //         $scope.loaisanphams = res.data;
    //         console.log(res.data);
    //     });
    // }
    // LayTTLoaiSP();
    $scope.saveData = function () {
        if ($scope.id == 0) {
            $http({
                method: "POST",
                url: api,
                data: $scope.sanpham,
                'content-Type': 'application/json'
            }).then(function (res) {
                $scope.sanpham = res.data;
                location.reload();
            });
        } else {
            $http({
                method: "PUT",
                url: api + $scope.id,
                data: $scope.sanpham,
                'content-Type': 'application/json'
            }).then(function (res) {
                $scope.sanpham = res.data;
                location.reload();
            });
        }
        $('#modelId').modal('hide');

    }
    $scope.deleteClick = function (id) {
        var hoi = confirm("Ban co muon xóa san pham nay khong?");
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