'use strict';

var appServices = angular.module('appServices', []);

appServices.service('globalFunctions', function () {
    var service = {
        
        _removeTime: function (date) {
            return date.day(1).hour(0).minute(0).second(0).millisecond(0);
        },

        _buildMonth: function (scope, start, month) {
        scope.weeks = [];
        var done = false, date = start.clone(), monthIndex = date.month(), count = 0;
        while (!done) {
            scope.weeks.push({ days: this._buildWeek(date.clone(), month) });
            date.add(1, "w");
            done = count++ > 2 && monthIndex !== date.month();
            monthIndex = date.month();
            }
        },

        _buildWeek: function (date, month) {
        var days = [];
        for (var i = 0; i < 7; i++) {
            days.push({
                name: date.format("dd").substring(0, 2),
                number: date.date(),
                isCurrentMonth: date.month() === month.month(),
                isToday: date.isSame(new Date(), "day"),
                date: date
            });
            date.add(1, "d");
            date = date.clone();
            }
        return days;
        }

    }
   
    return service;

})