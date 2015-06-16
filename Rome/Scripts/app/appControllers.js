﻿'use strict';

var appControllers = angular.module('appControllers', ['appServices']);

appControllers.controller('loginCtrl', [
    '$scope', '$http', 'loginService',
    function ($scope, $http, loginService) {
        $scope.invalidPassword = false;
        $scope.$watch(function () { return loginService.loggedIn },
            function (newValue, oldValue) {
                $scope.isLoggedIn = loginService.loggedIn;
            }
        );

        this.tryLogin = function (login, password) {
            var user = {
                UserName: login,
                Password: password
            };

            var requestBody = JSON.stringify(user);

            var request = {
                method: 'POST',
                url: '/api/Users/getUser/',
                data: requestBody
            }

            $http(request).success(function (data) {
                if (data != null) {
                    loginService.user = data;
                    loginService.loggedIn = true;
                    $scope.invalidPassword = false;
                } else {
                    $scope.invalidPassword = true;
                }
            }).error(function (error) {
                $scope.Error = error
            });
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
    '$scope', '$http', 'loginService', '$mdDialog', 'globalFunctions', 'selectedDayService',
    function ($scope, $http, loginService, $mdDialog, globalFunctions, selectedDayService) {
        
        $scope.day = moment();

        $scope.$watch(function () { return selectedDayService.selectedDay },
            function (newValue, oldValue) {
                $scope.day = angular.copy(selectedDayService.selectedDay);
            }
        );

        $scope.selectedIndex = 0;
        $scope.loading = true;

        $scope.showMonthPicker = showMonthPicker;

        var dataBody = JSON.stringify({"UserId": loginService.user.UserId});

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

        function showMonthPicker($event) {
            var parentE = angular.element('#calendar');
            $mdDialog.show({
                parent: parentE,
                targetEvent: $event,
                templateUrl: '/Home/Templates/monthPicker',
                locals: {
                    years: $scope.years,
                    months: $scope.months
                },
                controller: 'dateDialogCtrl'
            }).then(function (answer) {
                selectedDayService.selectedDay = moment({ year: answer["selectedYear"], month: answer["selectedMonth"] });
            });
        };
    }
]);

appControllers.controller('profileCtrl', [
    '$scope', 'loginService',
    function ($scope, loginService) {
        $scope.user = loginService.user;
    }
]);

appControllers.controller('dateDialogCtrl', [
    '$scope', '$mdDialog', 'globalFunctions', 
    function ($scope, $mdDialog, globalFunctions) {

        globalFunctions._createMonths($scope);
        globalFunctions._createYears($scope, 5);

        $scope.submitMonthPicker = submitMonthPicker;
        $scope.cancelMonthPicker = cancelMonthPicker;

        $scope.pickerData = {
            selectedMonth: moment().format('MMMM'),
            selectedYear: parseInt(moment().year('YYYY'))
        };

        function submitMonthPicker() {
            $mdDialog.hide($scope.pickerData);
        };

        function cancelMonthPicker() {
            $mdDialog.cancel();
        };
    }
]);