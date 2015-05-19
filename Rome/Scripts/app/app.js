var myApp = angular.module('myApp', ['ngMaterial']);

myApp.config(function ($mdThemingProvider) {
    $mdThemingProvider.theme('default')
    .primaryPalette('light-blue', {
        'default': '400',
        'hue-1': '100',
        'hue-2': '600',
        'hue-3': 'A100'
    })
    .accentPalette('orange', {
        'default': '200'
    });
});

myApp.controller('mainCtrl', function ($scope, $http) {
    $scope.loading = true;

    $http.get('/api/Clients/').success(function (data) {
        $scope.Clients = data;
        $scope.loading = false;
    });

});