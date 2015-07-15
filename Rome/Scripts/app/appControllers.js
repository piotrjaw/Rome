'use strict';

var appControllers = angular.module('appControllers', ['appServices']);

appControllers.controller('loginCtrl', [
    '$scope', '$http', 'loginService', 'selectedDayService',
    function ($scope, $http, loginService, selectedDayService) {
        $scope.variables = {
            invalidPassword: false,
            passwordForgotten: false,
            isLoggedIn: false,
            Error: undefined
        };

        $scope.$watch(function () { return loginService.user.isLoggedIn },
            function (newValue, oldValue) {
                $scope.variables.isLoggedIn = loginService.user.isLoggedIn;
            }
        );

        this.passwordForgotToggle = function () {
            $scope.variables.passwordForgotten = !$scope.variables.passwordForgotten;
        };

        this.tryLogin = function (login, password) {
            var userInput = {
                UserName: login,
                Password: password
            };

            selectedDayService.selectedDay = undefined;

            var requestBody = JSON.stringify(userInput);

            var request = {
                method: 'POST',
                url: '/api/Users/getUser/',
                data: requestBody
            }

            $http(request).success(function (data) {
                if (data != null) {
                    loginService.user = data;
                    loginService.user.isLoggedIn = true;
                    $scope.variables.invalidPassword = false;
                } else {
                    $scope.variables.invalidPassword = true;
                }
            }).error(function (error) {
                $scope.variables.Error = error
            });
        };

        this.tryLogout = function () {
            loginService.user.isLoggedIn = false;
        }
    }
]);

appControllers.controller('tabCtrl', [
    '$scope', 'loginService',
    function ($scope, loginService) {
        $scope.User = loginService.user;

        this.tab = 1;

        this.setTab = function (newValue) {
            this.tab = newValue;
        };

        this.isSet = function (tabName) {
            return this.tab === tabName;
        };
    }
]);

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
    '$scope', '$http', 'loginService',
    function ($scope, $http, loginService) {
        $scope.baseLoading = true;
        
        var dataBody = JSON.stringify(loginService.user);

        var request = {
            method: 'POST',
            url: '/api/Bases/getSelectedBases/',
            data: dataBody
        }

        $http(request).success(function (data) {
            $scope.Bases = data;
            $scope.baseLoading = false;
        }).error(function (data) {
            $scope.Bases = data;
            $scope.baseLoading = false;
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

        var tempDataBody = {
            UserId: loginService.user.UserId,
            SessionId: loginService.user.SessionId,
            Year: parserInt($scope.day.format("YYYY")),
            Month: parseInt($scope.day.format("MM"))
        }
        var dataBody = JSON.stringify(tempDataBody);
        
        var request = {
            method: 'POST',
            url: '/api/Events/getUserEvents/',
            data: dataBody
        }

        $http(request).success(function (data) {
            $scope.EventActions = data;
            $scope.loading = false;
        }).error(function (data) {
            $scope.Error = data;
            $scope.loading = false;
        });

        $scope.showMonthPicker = showMonthPicker;

        function showMonthPicker($event) {
            var parentE = angular.element(document.querySelector('#calendar'));
            $mdDialog.show({
                parent: parentE,
                targetEvent: $event,
                templateUrl: '/Home/Directives/monthPicker',
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