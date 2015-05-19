var myApp = angular.module('myApp', []);

myApp.controller('mainCtrl', function ($scope, $http) {
    $scope.loading = true;

    $http.get('/api/Clients/').success(function (data) {
        $scope.Clients = data;
        $scope.loading = false;
    });

});