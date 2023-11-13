/*
    namespace 命名空间
*/

// import { Drawing } from "./TS_Circle";

function drawAllShapes(shape: Drawing.IShape) {
    shape.draw();
}
drawAllShapes(new Drawing.Circle());
drawAllShapes(new Drawing.Triangle());

// tsc --removeComments .\TS\TS_Namespace\TestShape.ts
// tsc --removeComments --module commonjs .\TS\TS_Namespace\TestShape.ts   
// node .\TS\TS_Namespace\TestShape.js
