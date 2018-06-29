/// <binding BeforeBuild='build:dev' />
"use strict";

var gulp = require("gulp"),
    merge = require("merge-stream"),
    rimraf = require("rimraf"),
    bundleconfig2 = require("./package-mapping-config.js");

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