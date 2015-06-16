'use strict';

var appServices = angular.module('appServices', []);

appServices.service('globalFunctions', function () {
    var service = {

        _buildMonth: function (scope, start, month) {
            scope.weeks = [];
            var done = false, date = start.clone(), monthIndex = date.month(), count = 0;
            date = date.startOf('month').startOf('week');
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
                    date: moment(date),
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
                    date: moment(date)
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
                    date: moment(date)
                });
                date.add(1, 'H');
                date = angular.copy(date);
            }
        },

        _createMonths: function (scope) {
            scope.months = [];
            for (var i = 0; i < 12; i++) {
                scope.months.push(moment({ month: i }).format("MMMM"));
            };
        },

        _createYears: function (scope, diff) {
            scope.years = [];
            var currentYear = parseInt(moment().format("YYYY"));
            for (var i = 0; i < 2 * diff + 1; i++) {
                scope.years.push(currentYear + i - diff);
            }
        },
    }

    return service;

});

appServices.service('loginService', function () {

    var user = function () {
        this.userId = null,
        this.loggedIn = false;
    };

    return user;
});

appServices.service('selectedDayService', function() {

    var selectedDay = null;

    return null;

})