/*
    基础类型 Base type
    注意：TypeScript 和 JavaScript 没有整数类型
    tuple(元组), 数组一般由同种类型的值组成，但有时我们需要在单个变量中存储不同类型的值，这时候我们就可以使用元组
*/

class BaseTypeTuple {
    test(): void {
        let tupleX: [string, number];
        tupleX = ['TypeScript', 1];
        console.log(tupleX[0] + "," + tupleX[1]);    // TypeScript,1
        console.log(typeof tupleX);                  // object

        // 声明空元组
        let mytuple = [];
        // 初始化
        mytuple[0] = 120;           // error 不影响
        mytuple[1] = true;
        mytuple[2] = "ABC";
        console.log("mytuple[0]: " + mytuple[0]);           // mytuple[0]: 120
        console.log("mytuple[1]: " + mytuple[1]);           // mytuple[1]: true
        console.log("mytuple[2]: " + mytuple[2]);           // mytuple[2]: ABC

        // 创建元组
        let mytuple02 = [10, "Runoob", true];
        console.log(mytuple02[0] + ", " + mytuple02[1] + ", " + mytuple02[2]);     // 10, Runoob, true
    }
}

let baseTypeTuple = new BaseTypeTuple();
baseTypeTuple.test();

// tsc --removeComments .\TS\TS_BaseType\TS_BaseType_Tuple.ts --outFile .\TS\TS_BaseType\TS_BaseType_Tuple.js
// node .\TS\TS_BaseType\TS_BaseType_Tuple.js
