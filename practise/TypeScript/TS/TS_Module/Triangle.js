"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Triangle = void 0;
var Triangle = (function () {
    function Triangle() {
    }
    Triangle.prototype.draw = function () {
        console.log("Triangle is drawn (external module)");
    };
    return Triangle;
}());
exports.Triangle = Triangle;
