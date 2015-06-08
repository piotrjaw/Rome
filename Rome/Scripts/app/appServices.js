'use strict';

var appServices = angular.module('appServices', []);

appServices.service('globalFunctions', function () {
    var service = {
        
        _removeTime: function (date) {
            return date.day(1).hour(0).minute(0).second(0).millisecond(0);
        },

        _removeDayTime: function (date) {
            return moment(date).startOf('day').subtract(22, 'h');
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

        _buildWeekDays: function (scope, date) {
            var hours = [];
            var anyDate = angular.copy(date);
            anyDate.hour(0).minute(0).second(0).millisecond(0);
            for (var i = 0; i < 24; i++) {
                hours.push({
                    name: anyDate.format("HH:mm"),
                    hour: anyDate.hour(),
                    minute: anyDate.minute()
                });
                anyDate.add(1, 'H');
                anyDate = angular.copy(anyDate);
            }
            scope.days = [];
            for (var i = 0; i < 7; i++) {
                scope.days.push({
                    name: date.format("dd").substring(0, 2),
                    number: date.date(),
                    isToday: date.isSame(new Date(), "day"),
                    date: date,
                    hours: hours
                });
                date.add(1, "d");
                date = angular.copy(date);
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
                    date: date,
                });
                date.add(1, "d");
                date = angular.copy(date);
            }
            return days;
        },

        _buildDay: function (scope, date) {
            scope.hours = [];
            for (var i = 0; i < 24; i++) {
                scope.hours.push({
                    name: date.format("HH:mm"),
                    hour: date.hour(),
                    minute: date.minute(),
                    date: date
                });
                date.add(1, 'H');
                date = angular.copy(date);
            }
        },

    }
   
    return service;

})