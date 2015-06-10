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
    function($scope, $mdSidenav) {
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

        $http.get('/api/Bases/getBases/').success(function (data) {
            $scope.Bases = data;
            $scope.loading = false;
        }).error(function (data) {
            $scope.Error = data;
            $scope.loading = false;
        });

        $scope.baseOrder = '-BaseStart';
    }

]);

appControllers.controller('branchCtrl', [
    '$scope', '$http',
    function ($scope, $http) {
        $scope.loading = true;

        $http.get('/api/Administrations/getAdm/').success(function (data) {
            $scope.Administrations = data;
            $scope.loading = false;
        }).error(function (data) {
            $scope.Error = data;
            $scope.loading = false;
        });
    }
]);

appControllers.controller('calendarCtrl', [
    '$scope', '$http',
    function ($scope, $http, $mdDialog) {
        $scope.day = moment();
        $scope.selectedIndex = 0;
        $scope.loading = true;

        /*$http.get('/api/Events/').success(function (data) {
            $scope.Events = data;
            $scope.loading = false;
        }).error(function (err) {
            $scope.Error = data;
            $scope.loading = false;
        });*/
        
        var dataBody = JSON.stringify({"UserId":17,"MinEventDate":"2015-04-23T00:00:00.000Z","MaxEventDate":"2015-04-25T00:00:00.000Z"});

        var request = {
            method: 'POST',
            url: '/api/Events/getSelectedEvents/',
            data: dataBody
        }

        $http(request).success(function (data) {
            $scope.Events = data;
            $scope.loading = false;
        }).error(function (data) {
            $scope.Error = data;
            $scope.loading = false;
        });


    }
]);