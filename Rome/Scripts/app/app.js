﻿'use strict';

var myApp = angular.module('myApp', [
    'ngMaterial',
    'ngAnimate',
    'angular.filter',

    'appControllers',
    'appDirectives',
    'appFilters',
    'appServices'
])

.config([
    '$compileProvider',
    '$locationProvider',
    '$mdIconProvider',
    '$mdThemingProvider',
    '$httpProvider',
    function ($compileProvider, $locationProvider, $mdIconProvider, $mdThemingProvider, $httpProvider) {
        $compileProvider.debugInfoEnabled(false);
        $locationProvider.html5Mode(true).hashPrefix('!');
        $mdIconProvider.icon("logo", "/Img/Svg/TaxCare.svg", 64);
        $mdThemingProvider
            .theme('default')
            .primaryPalette('light-blue', {
                'default': '900',
                'hue-1': '800',
                'hue-2': '100',
                'hue-3': '500'
            })
            .accentPalette('deep-orange', {
                'default': 'A100',
                'hue-1': 'A400',
                'hue-2': 'A700'
            });
        $mdThemingProvider
            .theme('altTheme')
            .backgroundPalette('grey', {
                'default': '200'
            });
        $httpProvider.useApplyAsync(true);
}])