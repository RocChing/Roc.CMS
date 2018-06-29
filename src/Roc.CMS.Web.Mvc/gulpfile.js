/// <binding />
"use strict";

var gulp = require("gulp"),
    concat = require("gulp-concat"),
    cssmin = require("gulp-cssmin"),
    htmlmin = require("gulp-htmlmin"),
    uglify = require("gulp-uglify"),
    merge = require("merge-stream"),
    del = require("del"),
    gutil = require('gulp-util'),
    rimraf = require("rimraf"),
    bundleconfig = require("./bundleconfig.json"),
    bundleconfig2 = require("./package-mapping-config.js");

var regex = {
    css: /\.css$/,
    html: /\.(html|htm)$/,
    js: /\.js$/
};

gulp.task("min", ["min:js", "min:css", "min:html"]);

gulp.task('copy:node_modules', function () {
    rimraf.sync(bundleconfig2.libsFolder + '/**/*', { force: true });
    var tasks = [];

    for (var mapping in bundleconfig2.mappings) {
        if (bundleconfig2.mappings.hasOwnProperty(mapping)) {
            var destination = bundleconfig2.libsFolder + '/' + bundleconfig2.mappings[mapping];
            if (mapping.match(/[^/]+(css|js)$/)) {
                tasks.push(
                    gulp.src(mapping).pipe(gulp.dest(destination))
                );
            } else {
                tasks.push(
                    gulp.src(mapping + '/**/*').pipe(gulp.dest(destination))
                );
            }
        }
    }

    return merge(tasks);
});

gulp.task("min:js", function () {
    var tasks = getBundles(regex.js).map(function (bundle) {
        return gulp.src(bundle.inputFiles, { base: "." })
            .pipe(concat(bundle.outputFileName))
            .pipe(uglify())
             .on('error', function (err) {
                 gutil.log(gutil.colors.red('[Error]'), err.toString());
             })
            .pipe(gulp.dest("."));
    });
    return merge(tasks);
});

gulp.task("min:css", function () {
    var tasks = getBundles(regex.css).map(function (bundle) {
        return gulp.src(bundle.inputFiles, { base: "." })
            .pipe(concat(bundle.outputFileName))
            .pipe(cssmin())
            .pipe(gulp.dest("."));
    });
    return merge(tasks);
});

gulp.task("min:html", function () {
    var tasks = getBundles(regex.html).map(function (bundle) {
        return gulp.src(bundle.inputFiles, { base: "." })
            .pipe(concat(bundle.outputFileName))
            .pipe(htmlmin({ collapseWhitespace: true, minifyCSS: true, minifyJS: true }))
            .pipe(gulp.dest("."));
    });
    return merge(tasks);
});

gulp.task("clean", function () {
    var files = bundleconfig.map(function (bundle) {
        return bundle.outputFileName;
    });

    return del(files);
});

gulp.task("watch", function () {
    getBundles(regex.js).forEach(function (bundle) {
        gulp.watch(bundle.inputFiles, ["min:js"]);
    });

    getBundles(regex.css).forEach(function (bundle) {
        gulp.watch(bundle.inputFiles, ["min:css"]);
    });

    getBundles(regex.html).forEach(function (bundle) {
        gulp.watch(bundle.inputFiles, ["min:html"]);
    });
});

function getBundles(regexPattern) {
    return bundleconfig.filter(function (bundle) {
        return regexPattern.test(bundle.outputFileName);
    });
}