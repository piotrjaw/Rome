'use strict';

var myApp = angular.module('myApp', [
    'ngMaterial',
    'ngAnimate',
    'angular.filter',

    'appControllers',
    'appDirectives',
    'appFilters',
    'appServices'
]);

myApp.config(function ($locationProvider, $mdThemingProvider, $mdIconProvider) {
    $locationProvider.html5Mode(true).hashPrefix('!');

    $mdThemingProvider
        .theme('default')
        .primaryPalette('indigo', {
            'default': '500',
            'hue-1': '800',
            'hue-2': '100',
            'hue-3': '50'
        })
        .accentPalette('pink', {
            'default': 'A400',
            'hue-1': 'A100',
            'hue-2': 'A700'
        })
        .backgroundPalette('grey', {
            'default': '200'
        });

    $mdIconProvider
        .icon("logo", "/Img/Svg/TaxCare.svg", 64);
});

myApp.filter('jsDate', function () {
    return function (x) {
        if (!x) { return; }
        return new Date(parseInt(x.substr(6, 13)));
    };
});