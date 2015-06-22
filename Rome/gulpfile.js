var gulp = require('gulp');
var concat = require('gulp-concat');
var rename = require('gulp-rename');
var uglify = require('gulp-uglify');

var paths = {
    scripts: [
        './Scripts/app/app.js',
        './Scripts/app/appControllers.js',
        './Scripts/app/appServices.js',
        './Scripts/app/appFilters.js',
        './Scripts/app/appDirectives.js'
    ],
    vendor: [
        './Scripts/angular/angular.min.js',
        './Scripts/angular-animate/angular-animate.min.js',
        './Scripts/angular-aria/angular-aria.min.js',
        './Scripts/angular-filter/dist/angular-filter.min.js',
        './Scripts/angular-material/angular-material.min.js',
        './Scripts/moment/min/moment-with-locales.min.js',
        './Scripts/d3/d3.min.js'
    ],
    destination: './Scripts/app/'
}

gulp.task('default', function () {
});

gulp.task('concat', function () {
    gulp.src(paths.scripts)
        .pipe(concat('appsrc.js'))
        .pipe(gulp.dest(paths.destination))
        .pipe(rename({ extname: '.min.js' }))
        .pipe(uglify())
        .pipe(gulp.dest(paths.destination))
});

gulp.task('concat-vendor', function () {
    gulp.src(paths.vendor)
        .pipe(concat('vendor.js'))
        .pipe(gulp.dest(paths.destination))
        .pipe(rename({ extname: '.min.js' }))
        .pipe(uglify())
        .pipe(gulp.dest(paths.destination))
})