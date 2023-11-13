/*
*/

import shape = require("./IShape");
import circle = require("./Circle");
import triangle = require("./Triangle");


function drawAllShapes(shapeToDraw: shape.IShape) {
    shapeToDraw.draw();
}

drawAllShapes(new circle.Circle());                     // Cirlce is drawn (external module)
drawAllShapes(new triangle.Triangle());                 // Triangle is drawn (external module)

// tsc --removeComments --module amd .\TS\TS_Module\TestShape.ts            -- error
// tsc --removeComments --module commonjs .\TS\TS_Module\TestShape.ts     
// node .\TS\TS_Module\TestShape.js         
