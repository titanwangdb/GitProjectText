/*
    Type Guard  类型守卫
        类型保护是可执行运行时检查的一种表达式，用于确保该类型在一定的范围内。换句话说，类型保护可以保证一个字符串是一个字符串，尽管它的值也可以是一个数值。
        类型保护与特性检测并不是完全不同，其主要思想是尝试检测属性、方法或原型，以确定如何处理值
        目前主要有四种的方式来实现类型保护：
*/

// in 关键字
interface Admin {
    name: string;
    privileges: string[];
}

interface Employee {
    name: string;
    startDate: Date;
}

type UnknownEmployee = Employee | Admin;

function printEmployeeInformation(emp: UnknownEmployee) {
    console.log("Name: " + emp.name);
    if ("privileges" in emp) {
        console.log("Privileges: " + emp.privileges);
    }
    if ("startDate" in emp) {
        console.log("Start Date: " + emp.startDate);
    }
}

console.log("--------------in------------------");
let inter_admin: Admin = {
    name: "admin",
    privileges: ["aa", "bb", "cc"]
}
printEmployeeInformation(inter_admin);              // Name: admin              Privileges: aa,bb,cc

let inter_employee: Employee = {
    name: "employee",
    startDate: new Date()
}
printEmployeeInformation(inter_employee);           // Name: employee           Start Date: Thu Sep 07 2023 16:08:32 GMT+0800 (China Standard Time)





// typeof 关键字
function padLeft(value: string, padding: string | number) {
    if (typeof padding === "number") {          // !==
        return Array(padding + 1).join(" ") + value;
    }
    if (typeof padding === "string") {
        return padding + value;
    }
    throw new Error(`Expected string or number, got '${padding}'.`);
}

console.log("--------------typeof------------------");
console.log(padLeft("padding-string", "10"));           // 10padding-string
console.log(padLeft("padding-number", 20));             //                     padding-number   ----20 + 1 个空格






// instanceof 关键字
interface Padder {
    getPaddingString(): string;
}

class SpaceRepeatingPadder implements Padder {
    constructor(private numSpaces: number) { }
    getPaddingString() {
        return Array(this.numSpaces + 1).join(" ");
    }
}

class StringPadder implements Padder {
    constructor(private value: string) { }
    getPaddingString() {
        return this.value;
    }
}

console.log("--------------instanceof------------------");
let padder: Padder = new SpaceRepeatingPadder(6);
if (padder instanceof SpaceRepeatingPadder) {
    console.log("is SpaceRepeatingPadder");         // ok
} else {
    console.log("not SpaceRepeatingPadder");        // 
}





// 自定义类型保护的类型谓词
function isNumber(x: any): x is number {
    return typeof x === "number";
}

function isString(x: any): x is string {
    return typeof x === "string";
}

console.log("--------------自定义------------------");
console.log(isNumber(10));          // true
console.log(isString("ABC"));       // true



// tsc --removeComments .\TS\TS_TypeGuard.ts --outFile .\dict\TS_TypeGuard.js
// node .\dict\TS_TypeGuard.js
