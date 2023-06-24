var app = angular.module('myappsanpham', []).constant('api', 'http://localhost:18058/api/SanPham/');
app.controller('sanphamController', ['$scope', '$http', 'api', mycontroller]);

function mycontroller($scope, $http, api) {
    $http({
        method: "GET",
        url: api,
    }).then(function (res) {
        $scope.sanphams = res.data;
        console.log(res.data);
    });

    $http({
        method: "GET",
        url: 'http://localhost:18058/api/LoaiSanPham/',
    }).then(function (res) {
        $scope.loaisanphams = res.data;
        console.log(res.data);
    });

    $scope.addToCart = function (sp) {
        let item = {};
        item.id = sp.id;
        item.tenSP = sp.tenSP;
        item.giaBan = sp.giaBan;
        item.anh = sp.anh;
        item.quantity = 1;
        var list;
        if (localStorage.getItem('cart') == null) {
            list = [item];
        } else {
            list = JSON.parse(localStorage.getItem('cart')) || [];
            let ok = true;
            for (let x of list) {
                if (x.id == item.id) {
                    x.quantity += 1;
                    ok = false;
                    break;
                }
            }
            if (ok) {
                list.push(item);
            }
        }
        localStorage.setItem('cart', JSON.stringify(list));
        alert("Đã thêm giở hàng thành công");
        location.reload();
    }


    $scope.listSP = [];
    $scope.product_count = function () {
        var dem = 0;
        $scope.listSP = JSON.parse(localStorage.getItem('cart'));
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


}