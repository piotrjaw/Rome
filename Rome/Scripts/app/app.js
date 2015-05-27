'use strict';

var myApp = angular.module('myApp', [
    'ngMaterial',
    'ui',
    'ui.filters',

    'appControllers'
]);

myApp.config(function ($locationProvider, $mdThemingProvider) {
    $locationProvider.html5Mode(true).hashPrefix('!');

    $mdThemingProvider.theme('default')
    .primaryPalette('indigo', {
        'default': '400',
        'hue-1': '100',
        'hue-2': '600',
        'hue-3': 'A100'
    })
    .accentPalette('amber', {
        'default': '200'
    })
    .backgroundPalette('grey');
});

myApp.filter('jsDate', function () {
    return function (x) {
        if (!x) { return; }
        return new Date(parseInt(x.substr(6, 13)));
    };
});