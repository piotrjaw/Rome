'use strict';

var appControllers = angular.module('appControllers', []);

appControllers.controller('tabCtrl',
    function() {
        this.tab = 1;

        this.setTab = function (newValue) {
            this.tab = newValue;
        };

        this.isSet = function (tabName) {
            return this.tab === tabName;
        };
    }
);

appControllers.controller('mainCtrl', [
    '$scope', '$mdSidenav',
    function($scope, $http, $mdSidenav) {
        $scope.toggleSidenav = toggleSidenav;

        function toggleSidenav(name) {
            $mdSidenav(name).toggle();

        }
    }
]);

appControllers.controller('baseCtrl', [
    '$scope', '$http',
    function ($scope, $http) {
        $scope.loading = true;

        $http.get('/api/Bases/').success(function (data) {
            $scope.Bases = data;
            $scope.loading = false;
        }).error(function (err) {
            $scope.Error = err;
            $scope.loading = false;
        });

        $scope.baseOrder = '-BaseStart';
    }

]);

appControllers.controller('branchCtrl', [
    '$scope', '$http',
    function ($scope, $http) {
        $scope.loading = true;

        $http.get('/api/Administrations/').success(function (data) {
            $scope.Administrations = data;
            $scope.loading = false;
        }).error(function (err) {
            $scope.Error = err;
            $scope.loading = false;
        });
    }
]);