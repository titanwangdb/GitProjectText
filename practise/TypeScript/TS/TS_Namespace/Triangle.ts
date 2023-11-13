/*
    namespace 命名空间
*/

// import { IShape } from "./TS_IShape";

namespace Drawing { 
    export class Triangle implements IShape { 
        public draw() { 
            console.log("Triangle is drawn"); 
        } 
    } 
}


