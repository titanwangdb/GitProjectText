/*
    基础类型 Base type
    注意：TypeScript 和 JavaScript 没有整数类型
    boolean(布尔类型)
*/

class BaseTypeBoolean {
    test(): void {
        let flag: boolean = true;
        console.log(flag + ", " + typeof flag);          // true, boolean 
    }

}

let baseTypeBoolean = new BaseTypeBoolean();
baseTypeBoolean.test();

// tsc --removeComments .\TS\TS_BaseType\TS_BaseType_Boolean.ts --outFile .\TS\TS_BaseType\TS_BaseType_Boolean.js
// node .\TS\TS_BaseType\TS_BaseType_Boolean.js
