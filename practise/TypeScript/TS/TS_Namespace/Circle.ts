/*
    namespace 命名空间
*/

// import shape = require("./IShape");

namespace Drawing { 
    export class Circle implements IShape { 
        public draw() { 
            console.log("Circle is drawn"); 
        }  
    }
}

