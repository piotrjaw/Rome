'use strict';

var appControllers = angular.module('appControllers', []);

appControllers.controller('tabCtrl', ['$scope',
    function($scope) {
        $scope.tab = 1;

        $scope.setTab = function(newValue) {
            $scope.tab = newValue;
        };

        $scope.isSet = function(tabName) {
            return $scope.tab === tabName;
        };
    }
]);

appControllers.controller('mainCtrl', [
    '$scope', '$http', '$mdSidenav',
    function($scope, $http, $mdSidenav) {
        $scope.loading = true;
        $scope.toggleSidenav = toggleSidenav;

        $http.get('/api/Bases/').success(function(data) {
            $scope.Bases = data;
            $scope.loading = false;
        }).error(function(err) {
            $scope.Error = err;
            $scope.loading = false;
        });

        function toggleSidenav(name) {
            $mdSidenav(name).toggle();

        }
    }
]);