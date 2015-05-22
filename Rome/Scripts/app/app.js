var myApp = angular.module('myApp', ['ngMaterial', 'ui', 'ui.filters']);

myApp.config(function ($locationProvider, $mdThemingProvider) {
    $locationProvider.html5Mode(true).hashPrefix('!');

    $mdThemingProvider.theme('default')
    .primaryPalette('indigo', {
        'default': '400',
        'hue-1': '100',
        'hue-2': '600',
        'hue-3': 'A100'
    })
    .accentPalette('orange', {
        'default': '200'
    });
});

myApp.filter('jsDate', function () {
    return function (x) {
        if (!x) { return; }
        return new Date(parseInt(x.substr(6, 13)));
    };
});

myApp.controller('mainCtrl', ['$scope', '$http', '$mdSidenav', function ($scope, $http, $mdSidenav) {
    $scope.loading = true;
    $scope.toggleSidenav = toggleSidenav;

    $http.get('/api/Clients/').success(function (data) {
        $scope.Clients = data;
        $scope.loading = false;
    }).error(function (err) {
        $scope.Error = err;
        $scope.loading = false;
    });

    function toggleSidenav(name) {
        $mdSidenav(name).toggle();
    }

}]);