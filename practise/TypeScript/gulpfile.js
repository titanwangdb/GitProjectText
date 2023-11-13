/*
    hello word
*/
// let gulp = require("gulp");
// let ts = require("gulp-typescript");
// let tsProject = ts.createProject("tsconfig.json");

// gulp.task("default", function () {
//     return tsProject.src()
//         .pipe(tsProject())
//         .js.pipe(gulp.dest("dist"));
// });


/*
    showHello调用sayHello函数更改页面上段落的文字
*/
var gulp = require("gulp");
var browserify = require("browserify");
var source = require('vinyl-source-stream');
var tsify = require("tsify");
var paths = {
    pages: ['src/*.html']
};
// copy-html任务
gulp.task("copy-html", function () {
    return gulp.src(paths.pages)
        .pipe(gulp.dest("dist"));
});
// copy-html任务 作为 default 的依赖项,当 default执行时，copy-html会被首先执行
gulp.task("default", gulp.series("copy-html", function () {
    return browserify({
        basedir: '.',
        debug: true,                    // debug: true。 这会让 tsify 在输出文件里生成source maps。 source maps允许我们在浏览器中直接调试TypeScript源码
        entries: ['src/main.ts'],
        cache: {},
        packageCache: {}
    })
    .plugin(tsify)
    .bundle()                           // 调用bundle
    .pipe(source('bundle.js'))          // 输出文件命名为bundle.js
    .pipe(gulp.dest("dist"));
}));

/*
    Watchify, 实时调试
*/
// var gulp = require("gulp");
// var browserify = require("browserify");
// var source = require('vinyl-source-stream');
// var watchify = require("watchify");
// var tsify = require("tsify");
// var gutil = require("gulp-util");
// var paths = {
//     pages: ['src/*.html']
// };
// // 将browserify实例包裹在watchify的调用里，控制生成的结果
// var watchedBrowserify = watchify(browserify({
//     basedir: '.',
//     debug: true,
//     entries: ['src/main.ts'],
//     cache: {},
//     packageCache: {}
// }).plugin(tsify));

// gulp.task("copy-html", function () {
//     return gulp.src(paths.pages).pipe(gulp.dest("dist"));
// });

// function bundle() {
//     return watchedBrowserify
//         .bundle()
//         .pipe(source('bundle.js'))
//         .pipe(gulp.dest("dist"));
// }

// gulp.task("default", gulp.series("copy-html", bundle));     // 将 browserify 调用移出 default 任务
// watchedBrowserify.on("update", bundle);     // 每次TypeScript文件改变时Browserify会执行bundle函数
// watchedBrowserify.on("log", gutil.log);     // 将日志打印到控制台


/*
    Uglify, 混淆代码，生成 map 文件
*/
// var gulp = require("gulp");
// var browserify = require("browserify");
// var source = require('vinyl-source-stream');
// var tsify = require("tsify");
// var uglify = require('gulp-uglify');
// var sourcemaps = require('gulp-sourcemaps');
// var buffer = require('vinyl-buffer');
// var paths = {
//     pages: ['src/*.html']
// };

// gulp.task("copy-html", function () {
//     return gulp.src(paths.pages)
//         .pipe(gulp.dest("dist"));
// });

// gulp.task("default", gulp.series("copy-html", function () {
//     return browserify({
//         basedir: '.',
//         debug: true,
//         entries: ['src/main.ts'],
//         cache: {},
//         packageCache: {}
//     })
//     .plugin(tsify)
//     .bundle()
//     .pipe(source('bundle.js'))                  // 混淆代码
//     .pipe(buffer())
//     .pipe(sourcemaps.init({loadMaps: true}))
//     .pipe(uglify())
//     .pipe(sourcemaps.write('./'))
//     .pipe(gulp.dest("dist"));
// }));



/*
    Babel, 混淆代码     ES2015 --error
*/
// var gulp = require('gulp');
// var browserify = require('browserify');
// var source = require('vinyl-source-stream');
// var tsify = require('tsify');
// var sourcemaps = require('gulp-sourcemaps');
// var buffer = require('vinyl-buffer');
// var paths = {
//     pages: ['src/*.html']
// };

// gulp.task('copyHtml', function () {
//     return gulp.src(paths.pages)
//         .pipe(gulp.dest('dist'));
// });

// gulp.task("default", gulp.series("copyHtml", function () {
//     return browserify({
//         basedir: '.',
//         debug: true,
//         entries: ['src/main.ts'],
//         cache: {},
//         packageCache: {}
//     })
//     .plugin(tsify)
//     .transform('babelify', {
//         presets: ['es2015'],
//         extensions: ['.ts']
//     })
//     .bundle()
//     .pipe(source('bundle.js'))
//     .pipe(buffer())
//     .pipe(sourcemaps.init({loadMaps: true}))
//     .pipe(sourcemaps.write('./'))
//     .pipe(gulp.dest('dist'));
// }));
