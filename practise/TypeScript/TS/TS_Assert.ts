/*
    Assert 断言
        类型断言好比其他语言里的类型转换，但是不进行特殊的数据检查和解构。它没有运行时的影响，只是在编译阶段起作用。
*/

class DemoAssert {
    test(): void {
        // “尖括号” 语法
        let someValue: any = "this is a string";
        let strLength: number = (<string>someValue).length;
        console.log("length: " + strLength);            // length: 16

        // as 语法
        let someValue02: any = "this is a string";
        let strLength02: number = (someValue02 as string).length;
        console.log("length: " + strLength02);          // length: 16
    }
}

let da = new DemoAssert();
da.test();


// tsc --removeComments .\TS\TS_Assert.ts --outFile .\TS\TS_Assert.js
// node .\TS\TS_Assert.js
