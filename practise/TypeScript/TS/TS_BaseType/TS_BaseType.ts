/*
    基础类型 Base type
    注意：TypeScript 和 JavaScript 没有整数类型
*/

// any(任意类型)            声明为 any 的变量可以赋予任意类型的值
function BaseTypeAny() {
    // 数字类型
    let any_x: any = 1;
    console.log(typeof any_x);  // number
    // 字符串类型
    any_x = 'I am who I am';
    console.log(typeof any_x);  // string
    // 布尔类型
    any_x = false;
    console.log(typeof any_x);  // boolean
}


// Unknown 类型, 就像所有类型都可以赋值给 any，所有类型也都可以赋值给 unknown。这使得 unknown 成为 TypeScript 类型系统的另一种顶级类型（另一种是 any）
function BaseTypeUnknown() {
    let value: unknown;

    value = true;                   // OK
    value = 42;                     // OK
    value = "Hello World";          // OK
    value = [];                     // OK
    value = {};                     // OK
    value = Math.random;            // OK
    value = null;                   // OK
    value = undefined;              // OK
    value = new TypeError();        // OK
    // value = Symbol("type");
}



class DemoBaseType {
    // void	    用于标识方法返回值的类型，表示该方法没有返回值


    // null	    表示对象值缺失
    n: null = null;
    // undefined	 用于初始化变量为一个未定义的值
    u: undefined = undefined;

    // never	 代表从不会出现的值
    testNever(message: string): never {     // 返回值为 never 的函数可以是抛出异常的情况
        throw new Error(message);
    }
}


let dbt = new DemoBaseType();
// dbt.testNever();


// tsc --removeComments .\TS\TS_BaseType\TS_BaseType.ts --outFile .\TS\TS_BaseType\TS_BaseType.js
// node .\TS\TS_BaseType\TS_BaseType.js
