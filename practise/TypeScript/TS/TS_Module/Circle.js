"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Circle = void 0;
var Circle = (function () {
    function Circle() {
    }
    Circle.prototype.draw = function () {
        console.log("Cirlce is drawn (external module)");
    };
    return Circle;
}());
exports.Circle = Circle;
