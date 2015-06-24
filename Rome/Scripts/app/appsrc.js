'use strict';

var myApp = angular.module('myApp', [
    'ngMaterial',
    'ngAnimate',
    'angular.filter',

    'appControllers',
    'appDirectives',
    'appFilters',
    'appServices'
])

.config([
    '$compileProvider',
    '$locationProvider',
    '$mdIconProvider',
    '$mdThemingProvider',
    '$httpProvider',
    function ($compileProvider, $locationProvider, $mdIconProvider, $mdThemingProvider, $httpProvider) {
        $compileProvider.debugInfoEnabled(false);
        $locationProvider.html5Mode(true).hashPrefix('!');
        $mdIconProvider.icon("logo", "/Img/Svg/TaxCare.svg", 64);
        $mdThemingProvider
            .theme('default')
            .primaryPalette('light-blue', {
                'default': '900',
                'hue-1': '800',
                'hue-2': '200',
                'hue-3': '100'
            })
            .accentPalette('deep-orange', {
                'default': 'A400',
                'hue-1': 'A100',
                'hue-2': 'A700'
            });
        $mdThemingProvider
            .theme('altTheme')
            .backgroundPalette('grey', {
                'default': '200'
            });
        $httpProvider.useApplyAsync(true);
}])
'use strict';

var appControllers = angular.module('appControllers', ['appServices']);

appControllers.controller('loginCtrl', [
    '$scope', '$http', 'loginService', 'selectedDayService',
    function ($scope, $http, loginService, selectedDayService) {
        $scope.invalidPassword = false;
        $scope.$watch(function () { return loginService.user.isLoggedIn },
            function (newValue, oldValue) {
                $scope.isLoggedIn = loginService.user.isLoggedIn;
            }
        );

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
                    $scope.invalidPassword = false;
                } else {
                    $scope.invalidPassword = true;
                }
            }).error(function (error) {
                $scope.Error = error
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

        var dataBody = JSON.stringify(loginService.user);
        
        var request = {
            method: 'POST',
            url: '/api/Events/getSelectedEvents/',
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
'use strict';

var appServices = angular.module('appServices', []);

appServices.service('globalFunctions', function () {
    var service = {

        _buildMonth: function (scope, start, month) {
            scope.weeks = [];
            var done = false, date = start.clone(), monthIndex = date.month(), count = 0;
            date = date.startOf('month').startOf('week');
            while (!done) {
                scope.weeks.push({ days: this._buildWeek(date.clone(), month) });
                date.add(1, "w");
                done = count++ > 2 && monthIndex !== date.month();
                monthIndex = date.month();
            }
        },

        _buildWeekDays: function (scope, date) {
            var start = angular.copy(moment(date));
            var end = angular.copy(moment(start)).add(6, 'days');
            var additionalString = "";
            if (start.format('MM') !== end.format('MM')) { additionalString = start.format('-MM-YYYY') };
            scope.title = start.format('DD') + additionalString + " - " + end.format('DD-MM-YYYY');
            var hours = [];
            var anyDate = angular.copy(moment(date));
            anyDate.hour(0).minute(0).second(0).millisecond(0);
            for (var i = 0; i < 24; i++) {
                hours.push({
                    name: anyDate.format("HH:mm"),
                    hour: anyDate.hour(),
                    minute: anyDate.minute()
                });
                anyDate.add(1, 'H');
                anyDate = angular.copy(anyDate);
            }
            scope.days = [];
            for (var i = 0; i < 7; i++) {
                scope.days.push({
                    name: date.format('dddd').toUpperCase(),
                    number: date.date(),
                    isToday: date.isSame(new Date(), 'day'),
                    date: moment(date),
                    hours: hours
                });
                date.add(1, "d");
                date = angular.copy(date);
            }
        },

        _buildWeek: function (date, month) {
            var days = [];
            for (var i = 0; i < 7; i++) {
                days.push({
                    name: date.format("dd").substring(0, 2),
                    number: date.date(),
                    isCurrentMonth: date.month() === month.month(),
                    isToday: date.isSame(new Date(), "day"),
                    date: moment(date)
                });
                date.add(1, "d");
                date = angular.copy(date);
            }
            return days;
        },

        _buildDay: function (scope, date) {
            scope.hours = [];
            for (var i = 0; i < 24; i++) {
                scope.hours.push({
                    name: date.format("HH:mm"),
                    hour: date.hour(),
                    minute: date.minute(),
                    date: moment(date)
                });
                date.add(1, 'H');
                date = angular.copy(date);
            }
        },

        _createMonths: function (scope) {
            scope.months = [];
            for (var i = 0; i < 12; i++) {
                scope.months.push({
                    name: moment({ month: i }).format("MMMM"),
                    ind: i,
                    isCurrentMonth: moment().month() === moment({ month: i }).month()
                });
            };
        },

        _createYears: function (scope, diff) {
            scope.years = [];
            var currentYear = parseInt(moment().format("YYYY"));
            for (var i = 0; i < 2 * diff + 1; i++) {
                scope.years.push({
                    name: currentYear + i - diff,
                    isCurrentYear: currentYear + i - diff == currentYear
                });
            }
        },

        _createWeekDays: function (scope) {
            scope.weekdays = [];
            for (var i = 0; i < 7; i++) {
                scope.weekdays.push(moment().day(i).format("DDDD"));
            }
        }
    }

    return service;

});

appServices.service('loginService', function () {

    var user = function () {
        this.isLoggedIn = false;
    };

    return {
        user: user
    };
});

appServices.service('selectedDayService', function () {

    var selectedDay;

    return selectedDay;

})
'use strict';

var appFilters = angular.module('appFilters', [])

appFilters.filter('truncDate', [
    '$filter', function ($filter) {
        return function (input) {
            var newDate = moment(input).local().startOf('day');
            return $filter('date')(newDate);
        };
    }
]);

appFilters.filter('truncHour', [
    '$filter', function ($filter) {
        return function (input) {
            var newDate = moment(input).local().startOf('hour');
            return $filter('date')(newDate);
        };
    }
]);

appFilters.filter('jsDate', function () {
    return function (x) {
        if (!x) { return; }
        return new Date(parseInt(x.substr(6, 13)));
    };
});
'use strict';

var appDirectives = angular.module('appDirectives', ['appServices', 'appControllers']);

appDirectives.directive('calendar', ['globalFunctions', 'selectedDayService', function (globalFunctions, selectedDayService) {

    moment.locale('pl');

    return {
        controller: "calendarCtrl",
        restrict: 'E',
        templateUrl: '/Home/Directives/calendarTemplate',
        scope: {
            selected: '=',
            eventactions: '=',
            selectedindex: '='
        },
        link: function (scope) {

            selectedDayService.selectedDay = (scope.selected || moment().local().startOf('day'));

            scope.$watch(function () { return selectedDayService.selectedDay },
            function (newValue, oldValue) {
                    scope.month = angular.copy(selectedDayService.selectedDay);
                    var start = angular.copy(selectedDayService.selectedDay);
                    globalFunctions._buildMonth(scope, start, scope.month);
                }
            );

            scope.moveTo = function (day) {
                selectedDayService.selectedDay = day.date.startOf('day');
                scope.selectedindex = 2;
            };

            scope.next = function () {
                var next = angular.copy(scope.month).add(1, 'months');
                scope.month.month(scope.month.month() + 1);
                globalFunctions._buildMonth(scope, next, scope.month);
            };

            scope.previous = function () {
                var previous = angular.copy(scope.month).subtract(1, 'months');;
                scope.month.month(scope.month.month() - 1);
                globalFunctions._buildMonth(scope, previous, scope.month);
            };
        }
    }

}])

appDirectives.directive('calendarWeek', ['globalFunctions', 'selectedDayService', function (globalFunctions, selectedDayService) {

    moment.locale('pl');

    return {
        controller: "calendarCtrl",
        restrict: 'E',
        templateUrl: '/Home/Directives/calendarWeekTemplate',
        scope: {
            selected: '=',
            eventactions: '=',
            selectedindex: '='
        },
        link: function (scope) {
            scope.$watch(function () { return selectedDayService.selectedDay },
                function (newValue, oldValue) {
                    globalFunctions._buildWeekDays(scope, moment(selectedDayService.selectedDay).startOf('week'));
                }
            );

            scope.nextWeek = function () {
                selectedDayService.selectedDay.add(1, 'weeks');
                globalFunctions._buildWeekDays(scope, moment(selectedDayService.selectedDay).startOf('week'));
            };

            scope.previousWeek = function () {
                selectedDayService.selectedDay.subtract(1, 'weeks');
                globalFunctions._buildWeekDays(scope, moment(selectedDayService.selectedDay).startOf('week'));
            };
        }
    }

}]);

appDirectives.directive('calendarDay', ['globalFunctions', 'selectedDayService', function (globalFunctions, selectedDayService) {

    moment.locale('pl');

    return {
        controller: "calendarCtrl",
        restrict: 'E',
        templateUrl: '/Home/Directives/calendarDayTemplate',
        scope: {
            selected: '=',
            eventactions: '=',
            selectedindex: '='
        },
        link: function (scope) {

            scope.$watch(function () { return selectedDayService.selectedDay },
            function (newValue, oldValue) {
                var today = angular.copy(moment(selectedDayService.selectedDay).startOf('day'));
                globalFunctions._buildDay(scope, today);
            }
            );

            scope.nextDay = function () {
                selectedDayService.selectedDay = angular.copy(selectedDayService.selectedDay.add(1, 'days'));
            };

            scope.previousDay = function () {
                selectedDayService.selectedDay = angular.copy(selectedDayService.selectedDay.subtract(1, 'days'));
            };

            scope.pickDate = function (day) {
                scope.selected = angular.copy(day);
                scope.selectedindex = 0;
            };
        }
    }
}]);

appDirectives.directive('eventForm', ['$interval', function ($interval) {

    return {
        controller: "baseCtrl",
        restrict: 'E',
        templateUrl: '/Home/Directives/eventForm',
        scope: {
            baseoptionset: '=',
            client: '=',
            baseid: '='
        },
        link: function (scope) {

            scope.now = moment().startOf('hour').toDate();
            scope.max = moment().add(10, 'years').startOf('day').toDate();

            scope.submittedEvent = {
                NextEventDate: scope.now,
                Client: scope.client,
                BaseId: scope.baseid,
                Products: []
            };

            scope.clearSelectResult = function () {
                scope.submittedEvent.Products = [];
                scope.submittedEvent.ResignationReason = undefined;
                scope.submittedEvent.NextEvent = undefined;
                scope.submittedEvent.NextEventDate = scope.now;
            };

            scope.clearSelectType = function () {
                scope.clearSelectResult();
                scope.submittedEvent.Result = undefined;
            }

            scope.addProduct = function () {
                scope.submittedEvent.Products.push({ Count: scope.submittedEvent.Products.length + 1, Product: {}, Value: null });
            };

            scope.removeProduct = function () {
                var lastProductIndex = scope.submittedEvent.Products.length - 1;
                scope.submittedEvent.Products.splice(lastProductIndex);
            };

            scope.submitEvent = function () {
            };
        }
    }
}]);