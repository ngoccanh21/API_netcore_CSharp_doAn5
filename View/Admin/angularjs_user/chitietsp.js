var app = angular.module('myappsanpham', []);
app.config(['$locationProvider', function ($locationProvider) {
    $locationProvider.html5Mode({
        enabled: true,
        requireBase: false
    });
}]);

app.controller("sanphamController", function ($scope, $http, $location) {
    $scope.sp;
    $scope.LoadItem = function () {
        var id = $location.url().split('=')[1];
        $http({
            method: 'GET',
            url: "http://localhost:18058/api/SanPham/" + id,
        }).then(function (response) {
            $scope.sp = response.data;
            console.log(response.data);
        });
    };
    $scope.LoadItem();

    $scope.Getlsp = function () {
        $http({
            method: "GET",
            url: "http://localhost:18058/api/LoaiSanPham/GetLoaiSP",
        }).then(function (res) {
            $scope.loaisps = res.data;
            console.log(res.data);
        });
    };
    $scope.Getlsp();
    $scope.Getsanpham = function () {
        $http({
            method: "GET",
            url: "http://localhost:18058/api/SanPham/GetSanPham",
        }).then(function (res) {
            $scope.sanphams = res.data;
            console.log(res.data);
        });
    };
    $scope.Gettintuc = function () {
        $http({
            method: "GET",
            url: "http://localhost:28081/api/News/",
        }).then(function (res) {
            $scope.tintucs = res.data;
            console.log(res.data);
        });
    };
    $scope.News;
    $scope.LoadNews = function () {
        var id = $location.url().split('=')[1];
        $http({
            method: 'GET',
            url: "http://localhost:28081/api/News/" + id,
        }).then(function (response) {
            $scope.News = response.data;
            console.log(response.data);
        });
    };
    $scope.LoadNews();
    $scope.Gettintuc();
    $scope.Getsanpham();

});