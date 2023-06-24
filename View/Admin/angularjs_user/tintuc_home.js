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
}