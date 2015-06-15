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

myApp.config(function ($locationProvider, $mdIconProvider) {
    $locationProvider.html5Mode(true).hashPrefix('!');

    $mdIconProvider
        .icon("logo", "/Img/Svg/TaxCare.svg", 64);
});

myApp.config(function ($mdThemingProvider) {
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
});

myApp.config(function ($mdThemingProvider) {
    $mdThemingProvider
        .theme('altTheme')
        .backgroundPalette('grey', {
            'default': '200'
        });
});