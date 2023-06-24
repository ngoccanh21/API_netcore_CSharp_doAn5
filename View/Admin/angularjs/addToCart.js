
var app = angular.module('myapp', []);

app.controller('sanpham', function ($scope, $http, $window) {
    var api = 'http://localhost:18058/api/SanPham/';

    $http({
        Method: "GET",
        url: "http://localhost:18058/api/LoaiSanPham"
    }).success(function (response) {
        console.log(response);
        $scope.lsp = response;
    });
    $http({
        Method: "GET",
        url: api,
    }).success(function (response) {
        $scope.sanphams = response;
    });
    //  tenSP maLoai giaBan sale soLuong tinhTrang anh
    $scope.addToCart = function (sp) {
        let item = {};
        item.id = sp.id;
        item.tenSP = sp.tenSP;
        item.giaBan = sp.giaBan;
        item.anh = sp.anh;
        item.soLuong = 1;
        var list;
        if (localStorage.getItem('cartitem') == null) {
            list = [item];
        } else {
            list = JSON.parse(localStorage.getItem('cartitem')) || [];
            let ok = true;
            for (let x of list) {
                if (x.id == item.id) {
                    x.soLuong += 1;
                    ok = false;
                    break;
                }
            }
            if (ok) {
                list.push(item);
            }
        }
        localStorage.setItem('cartitem', JSON.stringify(list));
        alert("Đã thêm giở hàng thành công");
        location.reload();
    }
    $scope.listSP = [];
    /*=================== Thao tác dữ liệu ==================================== */


    $scope.product_count = function () {
        var dem = 0;
        $scope.listSP = JSON.parse(localStorage.getItem('cartitem'));
        if ($scope.listSP == null) {
            return dem = 0;
        }
        else {
            for (var i = 0; i < $scope.listSP.length; i++) {
                dem++;
            }
        }
        return dem;
    }

    $scope.sum = $scope.product_count();
    $scope.currentPage = 1;
    $scope.pageChangeHandler = function (num) {
        $scope.currentPage = num;
    };
    $scope.pageSize = 10;




});