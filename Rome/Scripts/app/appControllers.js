'use strict';

var appControllers = angular.module('appControllers', []);

appControllers.controller('tabCtrl',
    function() {
        this.tab = 1;

        this.setTab = function (newValue) {
            this.tab = newValue;
            console.log(this.tab);
        };

        this.isSet = function (tabName) {
            return this.tab === tabName;
        };
    }
);

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