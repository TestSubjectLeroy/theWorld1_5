﻿var gulp = require("gulp");

var uglify = require('gulp-uglify');
var concat = require('gulp-concat');
var rimraf = require("rimraf");
var merge = require('merge-stream');

gulp.task("minify", function () {

    var streams = [
        gulp.src(["wwwroot/js/*.js", '!wwwroot/js/tour*.js', '!wwwroot/js/contact.js'])
            .pipe(uglify())
            .pipe(concat("wilderblog.min.js"))
            .pipe(gulp.dest("wwwroot/lib/site")),
        gulp.src(["wwwroot/js/contact.js"])
            .pipe(uglify())
            .pipe(concat("contact.min.js"))
            .pipe(gulp.dest("wwwroot/lib/site"))
    ];

    return merge(streams);
});

// Dependency Dirs
var deps = {
    "jquery": {
        "dist/*": ""
    },
    "bootstrap": {
        "dist/**/*": ""
    },
    "font-awesome": {
        "css/*": "css",
        "fonts/*": "fonts"
    },
    "cookieconsent": {
        "build/*": ""
    },
    "highlightjs": {
        "*.js": "",
        "styles/*": "styles"
    },
    "lodash": {
        "lodash*.*": ""
    },
    "popper.js": {
        "dist/*": ""
    },
    "respond.js": {
        "dest/*": ""
    },
    "tether": {
        "dist/**/*": ""
    },
    "vue": {
        "dist/*": ""
    },
    "vee-validate": {
        "dist/*": ""
    },
    "vue-resource": {
        "dist/*": ""
    },
    "underscore": {
        "*/": ""
    },
    "jquery-validation": {
        "dist/*": ""
    },
      "jquery-validation-unobtrusive": {
        "dist/*": ""
    },
    "font-awesome": {
        "*/*": ""
    },
    "angular": {
        "*/": ""
    },
    "angular-route": {
        "*/": ""
    }



};

gulp.task("clean", function (cb) {
    return rimraf("wwwroot/vendor/", cb);
});

gulp.task("scripts", function () {

    var streams = [];

    for (var prop in deps) {
        console.log("Prepping Scripts for: " + prop);
        for (var itemProp in deps[prop]) {
            streams.push(gulp.src("node_modules/" + prop + "/" + itemProp)
                .pipe(gulp.dest("wwwroot/vendor/" + prop + "/" + deps[prop][itemProp])));
        }
    }

    return merge(streams);

});

gulp.task("default", ['clean', 'minify', 'scripts']);

