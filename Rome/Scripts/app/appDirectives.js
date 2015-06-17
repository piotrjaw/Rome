'use strict';

var appDirectives = angular.module('appDirectives', ['appServices', 'appControllers']);

appDirectives.directive('calendar', ['globalFunctions', 'selectedDayService', function (globalFunctions, selectedDayService) {

    moment.locale('pl');

    return {
        controller: "calendarCtrl",
        restrict: 'E',
        templateUrl: '/Home/Templates/calendarTemplate',
        scope: {
            selected: '=',
            events: '=',
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
        templateUrl: '/Home/Templates/calendarWeekTemplate',
        scope: {
            selected: '=',
            events: '=',
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
        templateUrl: '/Home/Templates/calendarDayTemplate',
        scope: {
            selected: '=',
            events: '=',
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
}])