'use strict';

var appFilters = angular.module('appFilters', [])

appFilters.filter('momentDate', [
    '$filter', function ($filter) {
        return function (input) {
            return $filter('date')(moment(input));
        };
    }
]);

appFilters.filter('truncDate', [
    '$filter', function ($filter) {
        return function (input) {
            return $filter('date')(input.hour(-22).minute(0).second(0).millisecond(0));
        };
    }
]);