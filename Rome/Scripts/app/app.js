'use strict';

var myApp = angular.module('myApp', [
    'ngMaterial',
    'ngAnimate',

    'appControllers',
    'appDirectives',
    'appServices'
]);

myApp.config(function ($locationProvider, $mdThemingProvider, $mdIconProvider) {
    $locationProvider.html5Mode(true).hashPrefix('!');

    $mdThemingProvider
        .theme('default')
        .primaryPalette('indigo', {
            'default': '400',
            'hue-1': '100',
            'hue-2': '600',
            'hue-3': 'A100'
        })
        .accentPalette('pink', {
            'default': '200'
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