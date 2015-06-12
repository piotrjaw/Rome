'use strict';

var appControllers = angular.module('appControllers', ['appServices']);

appControllers.controller('loginCtrl', [
    '$scope', 'loginService',
    function ($scope, loginService) {
        $scope.login = null;
        $scope.password = null;
        $scope.invalidPassword = false;
        $scope.$watch(function() { return loginService.loggedIn },
            function (newValue, oldValue) {
                $scope.isLoggedIn = loginService.loggedIn;
            }
        );

        this.tryLogin = function (login, password) {
            if (login === "pjaworski" && password === "test1234") {
                loginService.loggedIn = true;
                loginService.UserId = 17;
                $scope.invalidPassword = false;
            } else {
                $scope.invalidPassword = true;
            }
        };

        this.tryLogout = function () {
            loginService.loggedIn = false;
        }
    }
]);

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
    '$scope', '$http', 'loginService',
    function ($scope, $http, loginService) {
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
        
        var dataBody = JSON.stringify({"UserId": loginService.UserId});

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