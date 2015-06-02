'use strict';

var appFilters = angular.module('appFilters', [])

appFilters.filter('momentDate', [
    '$filter', function ($filter) {
        return function (input) {
            return $filter('date')(moment(input));
        };
    }
]);