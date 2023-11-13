/*
    基础类型 Base type
    注意：TypeScript 和 JavaScript 没有整数类型
    number(数字类型)	        双精度 64 位浮点值。用来表示整数和分数
*/

class BaseTypeNumber {
    test(): void {
        // Number 对象
        let num = new Number(177.1234);             
        console.log(typeof num + ", " + num);       // object, 177.1234

        // number 类型
        let binaryLiteral: number = 0b1010;         // 二进制
        let octalLiteral: number = 0o744;           // 八进制
        let decLiteral: number = 6;                 // 十进制
        let hexLiteral: number = 0xf00d;            // 十六进制

        console.log(binaryLiteral + " " + typeof binaryLiteral);          // 10 number
        console.log(octalLiteral + " " + typeof octalLiteral);            // 484 number
        console.log(decLiteral + " " + typeof decLiteral);                // 6 number
        console.log(hexLiteral + " " + typeof hexLiteral);                // 61453 number
    }

}

let baseTypeNumber = new BaseTypeNumber();
baseTypeNumber.test();

// tsc --removeComments .\TS\TS_BaseType\TS_BaseType_Number.ts --outFile .\TS\TS_BaseType\TS_BaseType_Number.js
// node .\TS\TS_BaseType\TS_BaseType_Number.js
