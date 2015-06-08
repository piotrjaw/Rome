'use strict';

var appDirectives = angular.module('appDirectives', ['appServices', 'appControllers']);

appDirectives.directive('calendar', ['globalFunctions', function (globalFunctions) {

    moment.locale('pl');

    return {
        restrict: 'E',
        templateUrl: '/Home/Templates/calendarTemplate',
        scope: {
            selected: '=',
            events: '=',
            selectedindex: '='
        },
        link: function (scope) {

            scope.selected = globalFunctions._removeTime(scope.selected || moment());
            scope.month = angular.copy(scope.selected);

            var start = angular.copy(scope.selected);
            start.date(1);
            globalFunctions._removeTime(start.day(0));

            globalFunctions._buildMonth(scope, start, scope.month);

            scope.moveTo = function (day) {
                scope.selected = globalFunctions._removeDayTime(day.date);
                scope.selectedindex = 2;
            };

            scope.next = function () {
                var next = angular.copy(scope.month);
                globalFunctions._removeTime(next.month(next.month() + 1).date(1));
                scope.month.month(scope.month.month() + 1);
                globalFunctions._buildMonth(scope, next, scope.month);
            };

            scope.previous = function () {
                var previous = angular.copy(scope.month);
                globalFunctions._removeTime(previous.month(previous.month() - 1).date(1));
                scope.month.month(scope.month.month() - 1);
                globalFunctions._buildMonth(scope, previous, scope.month);
            };
        }
    }

}])

appDirectives.directive('calendarWeek', ['globalFunctions', function (globalFunctions) {

    moment.locale('pl');

    return {
        restrict: 'E',
        templateUrl: '/Home/Templates/calendarWeekTemplate',
        scope: {
            selected: '=',
            events: '='
        },
        link: function (scope) {

            scope.selected = globalFunctions._removeTime(scope.selected || moment());

            var start = angular.copy(scope.selected);
            globalFunctions._removeTime(start.day(1));

            globalFunctions._buildWeekDays(scope, start);
        }

    }

}]);

appDirectives.directive('calendarDay', ['globalFunctions', function (globalFunctions) {

    moment.locale('pl');

    return {
        restrict: 'E',
        templateUrl: '/Home/Templates/calendarDayTemplate',
        scope: {
            selected: '=',
            events: '='
        },
        link: function (scope) {

            scope.selected = globalFunctions._removeDayTime(scope.selected || moment());
            var today = angular.copy(scope.selected);

            globalFunctions._buildDay(scope, today);


        }
    }
}])