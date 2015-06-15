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

            scope.selected = (scope.selected || moment().local().startOf('day'));
            scope.month = angular.copy(scope.selected); 

            var start = angular.copy(scope.selected);

            globalFunctions._buildMonth(scope, start, scope.month);

            scope.moveTo = function (day) {
                scope.selected = day.date.startOf('day');
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

            scope.selected = (scope.selected || moment().local().startOf('day'));

            var start = angular.copy(scope.selected);

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

            var today = angular.copy(scope.selected.startOf('day'));

            scope.$watch(function () { return scope.selected },
            function (newValue, oldValue) {
                    today = angular.copy(scope.selected.startOf('day'));
                    globalFunctions._buildDay(scope, today);
                }
            );

            scope.nextDay = function () {
                scope.selected = angular.copy(scope.selected.add(1, 'days'));
            };

            scope.previousDay = function () {
                scope.selected = angular.copy(scope.selected.subtract(1, 'days'));
            };
        }
    }
}])