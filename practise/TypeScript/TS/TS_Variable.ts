/*
    变量 variable
        
*/

const global_num = 3.14;          // // 全局变量

/*
    变量名称可以包含数字和字母
    除了下划线 _ 和美元 $ 符号外，不能包含其他特殊字符，包括空格
    变量名不能以数字开头
*/
class DemoVariable {
    num_val = 2020;             // 实例变量
    static sval = 1998;         // 静态变量

    dvTest(): void {
        // 使用 var 来声明变量
        // var [变量名] : [类型] = 值;
        let message: string = "Hello World!"    // 局部变量
        console.log(message)

        // 声明变量的类型，没有初始值，变量值会设置为 undefined
        var uname: string;

        // 声明变量并初始值，不设置类型，该变量可以是任意类型
        uname = "TypeScript";

        var uname: string = "TypeScript";
        let score1: number = 50;
        let score2: number = 42.50
        let sum = score1 + score2
        console.log("name: " + uname)
        console.log("score1: " + score1)
        console.log("score2: " + score2)
        console.log("sum: " + sum)
    }

    // 类型断言(Type Assertion)
    dvTypeAssertion(): void {
        let str = '1'
        let str2: number = <number><any>str   //str、str2 是 string 类型
        console.log(str2)                                   // 1
        console.log(typeof str + "," + typeof str2)         // string,string
    }
}

let dv = new DemoVariable();
dv.dvTest();
dv.dvTypeAssertion();

// 全局变量
console.log("global_num: " + global_num);                   // global_num: 3.14
// 实例变量
console.log("num_val: " + dv.num_val);                      // num_val: 2020
// 静态变量
console.log("DemoVariable.sval: " + DemoVariable.sval);     // DemoVariable.sval: 1998


// tsc --removeComments .\TS\TS_Variable.ts --outFile .\dict\TS_Variable.js
// node .\dict\TS_Variable.js
