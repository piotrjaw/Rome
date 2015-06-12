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

appFilters.filter('jsDate', function () {
    return function (x) {
        if (!x) { return; }
        return new Date(parseInt(x.substr(6, 13)));
    };
});