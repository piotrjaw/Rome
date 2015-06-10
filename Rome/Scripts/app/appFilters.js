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
            var newDate = moment(input).hour(-22).minute(0).second(0).millisecond(0);
            return $filter('date')(newDate);
        };
    }
]);

appFilters.filter('truncDate2', [
    '$filter', function ($filter) {
        return function (input) {
            var newDate = moment(input).hour(0).minute(0).second(0).millisecond(0);
            return $filter('date')(newDate);
        };
    }
]);

appFilters.filter('truncDate3', [
    '$filter', function ($filter) {
        return function (input) {
            var newDate = moment(input).hour(2).minute(0).second(0).millisecond(0);
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