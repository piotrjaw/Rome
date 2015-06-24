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
            client: '='
        },
        link: function (scope) {

            scope.now = null;

            $interval(function () {
                scope.now = moment().format('YYYY-MM-DD hh:mm:ss');
            }, 1000);

            scope.submittedEvent = {
                Client: scope.client,
                Products: []
            };

            scope.clearSelectResult = function () {
                scope.submittedEvent.Products = [];
                scope.submittedEvent.ResignationReason = undefined;
                scope.submittedEvent.NextEvent = undefined;
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
        }
    }
}]);