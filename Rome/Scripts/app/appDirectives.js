'use strict';

var appDirectives = angular.module('appDirectives', ['appServices']);

appDirectives.directive('calendar', ['globalFunctions', function (globalFunctions) {

    moment.locale('pl');

    return {
        restrict: 'E',
        templateUrl: '/Home/Templates/calendarTemplate',
        scope: {
            selected: '='
        },
        link: function (scope) {

            scope.selected = globalFunctions._removeTime(scope.selected || moment());
            scope.month = scope.selected.clone();

            var start = scope.selected.clone();
            start.date(1);
            globalFunctions._removeTime(start.day(0));

            globalFunctions._buildMonth(scope, start, scope.month);

            scope.select = function (day) {
                scope.selected = day.date;
            };

            scope.next = function () {
                var next = scope.month.clone();
                globalFunctions._removeTime(next.month(next.month() + 1).date(1));
                scope.month.month(scope.month.month() + 1);
                globalFunctions._buildMonth(scope, next, scope.month);
            };

            scope.previous = function () {
                var previous = scope.month.clone();
                globalFunctions._removeTime(previous.month(previous.month() - 1).date(1));
                scope.month.month(scope.month.month() - 1);
                globalFunctions._buildMonth(scope, previous, scope.month);
            };
        }
    }

}]);

appDirectives.directive('calendar-week', ['globalFunctions', function (globalFunctions) {

    return {
        restrict: 'E',
        templateUrl: '/Home/Templates/calendarWeekTemplate',
        scope: {
            selected: "="
        },
        link: function (scope) {

            scope.selected = globalFunctions._removeTime(scope.selected || moment());
            scope.month = scope.selected.clone();

            var start = scope.selected.clone();
            start.date(1);
            globalFunctions._removeTime(start.day(0));

            globalFunctions._buildMonth(scope, start, scope.month);

            scope.select = function (day) {
                scope.selected = day.date;
            };

            scope.next = function () {
                var next = scope.month.clone();
                globalFunctions._removeTime(next.month(next.month() + 1).date(1));
                scope.month.month(scope.month.month() + 1);
                globalFunctions._buildMonth(scope, next, scope.month);
            };

            scope.previous = function () {
                var previous = scope.month.clone();
                globalFunctions._removeTime(previous.month(previous.month() - 1).date(1));
                scope.month.month(scope.month.month() - 1);
                globalFunctions._buildMonth(scope, previous, scope.month);
            };
        }

    }

}])