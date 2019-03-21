"use strict"

var gulp = require("gulp")
var sass = require("gulp-sass")

sass.compiler = require("node-sass")

gulp.task("sass", function() {
  return gulp
    .src("./src/scss/*.scss")
    .pipe(sass().on("error", sass.logError))
    .pipe(gulp.dest("./public/css"))
})

gulp.task("watch:sass", function() {
  gulp.watch("./src/scss/*.scss", gulp.series("sass"))
})

// gulp.task("watch", function() {
//   gulp.watch("./src/**", gulp.series("gatsby serve"))
// })

gulp.task("build", gulp.task("sass"))
gulp.task("default", gulp.series("sass", "watch:sass"))
