/*
    函数 Function 
*/

let first = "Typescript";
let second = " World";


// 
function test(): void {
    const message: string = "Hello World!"
    console.log(message)
}
console.log("-------test---------");
test();                         // Hello World!



// 返回值
function testReturn(s: string): string {
    return s;
}
console.log("-------返回值---------");
console.log(testReturn(first));            // TypeScript




// 可选参数
function testParameter(first: string, second?: string): string {
    if (second == undefined) {
        return first;
    } else {
        return first + second;
    }
}
console.log("-------可选参数---------");
console.log(testParameter(first));           // Typescript
console.log(testParameter(first, second));   // Typescript World




// 默认参数
function testDefaultParameter(first: string = " ABC", second: string = " AAA"): string {
    return first + second;
}
console.log("-------默认参数---------");
console.log(testDefaultParameter());                // ABC AAA
console.log(testDefaultParameter(first));           // Typescript AAA
console.log(testDefaultParameter(first, second));   // Typescript World




/*
剩余参数
    有一种情况，我们不知道要向函数传入多少个参数，这时候我们就可以使用剩余参数来定义。
    剩余参数语法允许我们将一个不确定数量的参数作为一个数组传入。
*/
function testResidualParameter(...nums: number[]): number {       // 参数组成数组
    let sum: number = 0;

    for (let i = 0; i < nums.length; i++) {
        sum = sum + nums[i];
    }
    return sum;
}

function testResidualParameter02(array, ...items) {
    items.forEach(function (item) {
        array.push(item);
    });
}

console.log("-------剩余参数---------");
console.log(testResidualParameter(1, 2, 3));        // 6
console.log(testResidualParameter(10, 10));         // 20

let array_ResidualParameter = [];
testResidualParameter02(array_ResidualParameter, 12, 22, 32);
for (var x of array_ResidualParameter) {
    console.log(x);                                 // 12 22 32
}



/*
匿名函数
    匿名函数是一个没有函数名的函数。
    匿名函数在程序运行时动态声明，除了没有函数名外，其他的与标准函数一样。
    我们可以将匿名函数赋值给一个变量，这种表达式就成为函数表达式
*/
let msg = function () {
    return "hello world";
}
console.log("-------匿名函数---------");
console.log(msg());                     // hello world


// 带参数匿名函数
let res = function (x: number, y: number) {
    return x * y;
};
console.log("-------带参数匿名函数---------");
console.log(res(12, 2));                // 24




console.log("-------匿名函数自调用---------");
// 匿名函数自调用
(function () {
    let x = "Hello!!";
    console.log(x)          // Hello!!
})()



// 构造函数
var myFunction = new Function("a", "b", "return a * b");
var myFunctionC = myFunction(4, 3);
console.log("-------构造函数---------");
console.log(myFunctionC);             // 4 * 3 = 12



/*
递归函数
    递归函数即在函数内调用函数本身
*/
function factorial(number) {
    if (number <= 0) {
        return 1;
    } else {
        return (number * factorial(number - 1));     // 调用自身
    }
};
console.log("-------递归函数---------");
console.log(factorial(3));      // 3 * 2 * 1 = 6




// Lambda 函数
let foo = (x: number) => 10 + x;
console.log("-------Lambda 函数---------");
console.log(foo(100));           // 100 + 10 = 110




// 不指定函数的参数类型，通过函数内来推断参数类型
var func = (x) => {
    if (typeof x == "number") {
        console.log(x + " type is number")
    } else if (typeof x == "string") {
        console.log(x + " type is string")
    }
}
console.log("-------不指定函数的参数类型---------");
func(12);                   // 12 type is number
func("Tom");                // Tom type is string

// 单个参数 () 是可选的
var display = x => {
    console.log(x)
}
console.log("-------单个参数---------");
display(12);                // 12     

// 无参数时可以设置空括号
var disp = () => {
    console.log("Function invoked");
}
console.log("-------无参数时可以设置空括号---------");
disp();                     // Function invoked




/*
函数重载
    重载是方法名字相同，而参数不同，返回类型可以相同也可以不同。
*/
// 定义重载签名
function testFunctionOverloading(s1: string): void;
function testFunctionOverloading(n1: number, s1: string): void;
function testFunctionOverloading(n1: number): void;
// 定义实现签名
function testFunctionOverloading(x: any, y?: any): void {
    console.log(x + ", " + y);
}
console.log("-------函数重载---------");
testFunctionOverloading("abc");             // abc, undefined
testFunctionOverloading(1, "xyz");          // 1, xyz





// 数组在函数中的使用
let sites: string[] = new Array("Google", "Runoob", "Taobao", "Facebook");
function displaySites(arr_sites: string[]) {
    for (let i = 0; i < arr_sites.length; i++) {
        console.log(arr_sites[i])
    }
}
console.log("-------数组在函数中的使用---------");
displaySites(sites);                    // Google Runoob Taobao Facebook

// 数组作为函数的返回值
function displaySites02(): string[] {
    let sites: string[] = new Array("Google02", "Runoob02", "Taobao02", "Facebook02");
    return sites;
}
console.log("-------数组作为函数的返回值---------");
let sites02: string[] = displaySites02()
for (let i in sites02) {
    console.log(sites02[i])               // Google02 Runoob02 Taobao02 Facebook02
}




// 箭头函数
// 未使用箭头函数
function Book() {
    let self = this;
    self.publishDate = 2020;
    // setInterval 方法 用于在一定的时间间隔内重复执行指定的函数或代码块
    setInterval(function () {
        console.log(self.publishDate);
    }, 3000);
}

// 使用箭头函数
function Book02() {
    this.publishDate = 2022;
    setInterval(() => {
        console.log(this.publishDate);
    }, 3000);
}
console.log("-------箭头函数---------");
// Book();                 //       暂不执行
// Book02();               //



// tsc --removeComments .\TS\TS_Function.ts --outFile .\dict\TS_Function.js
// node .\dict\TS_Function.js