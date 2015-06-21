var gulp = require('gulp');
var concat = require('gulp-concat');
var rename = require('gulp-rename');
var uglify = require('gulp-uglify');

var paths = {
    scripts: [
        './Scripts/app/app.js',
        './Scripts/app/appControllers.js',
        './Scripts/app/appDirectives.js',
        './Scripts/app/appFilters.js',
        './Scripts/app/appServices.js',
    ],
    destination: './Scripts/app/'
}

gulp.task('default', function () {
});

gulp.task('concat', function () {
    gulp.src(paths.scripts)
        .pipe(concat('app.c.js'))
        .pipe(gulp.dest(paths.destination))
        .pipe(rename({ extname: '.min.js' }))
        .pipe(uglify())
        .pipe(gulp.dest(paths.destination))
});