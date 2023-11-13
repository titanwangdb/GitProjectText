/*
    Interface
        接口是对行为的抽象，而具体如何行动需要由类去实现。
*/


// 
interface IPerson {
    firstName: string,
    lastName: string,
    sayHi: () => string,
    // readonly name: string,  // 只读属性      暂时不会
    age?: number,           // 可选属性
}
console.log("------------IPerson--------------");
let customer: IPerson = {
    firstName: "Tom",
    lastName: "Hanks",
    sayHi: (): string => { return "Hi sayHi()" },
    age: 10
}
console.log(customer.firstName + ", " + customer.lastName + ", " + customer.sayHi() + ", " + customer.age);             // Tom, Hanks, Hi sayHi(), 10
let employee: IPerson = {
    firstName: "Jim",
    lastName: "Blakes",
    sayHi: (): string => { return "Hello!!!" }
}
console.log(employee.firstName + ", " + employee.lastName);     // Jim, Blakes
console.log(typeof customer + ", " + typeof employee);          // object, object



console.log("------------联合类型和接口--------------");
// 联合类型和接口
interface RunOptions {
    program: string;
    commandline: string[] | string | (() => string);
}

// commandline 是字符串
let options: RunOptions = { program: "test1", commandline: "Hello" };
console.log(options.commandline);
// commandline 是字符串数组
options = { program: "test1", commandline: ["Hello", "World"] };
console.log(options.commandline[0] + ", " + options.commandline[1]);        // 
// commandline 是一个函数表达式
options = { program: "test1", commandline: () => { return "**Hello World**"; } };
let fn: any = options.commandline;
console.log("fn: " + fn());




console.log("------------接口和数组--------------");
// 接口和数组
interface namelist {
    [index: number]: string
}

let list2: namelist = ["Google", "Runoob", "Taobao"];
console.log("list2: " + list2);         // list2: Google,Runoob,Taobao



// 接口继承
// 接口继承就是说接口可以通过其他接口来扩展自己
interface Person {
    age: number
}

interface Musician extends Person {
    instrument: string
}

console.log("------------接口继承--------------");
let drummer = <Musician>{};
drummer.age = 27;
drummer.instrument = "Drums";
console.log("age: " + drummer.age + ", instrument: " + drummer.instrument);                         // age: 27, instrument: Drums



// 多继承实例
interface IParent1 {
    v1: number
}

interface IParent2 {
    v2: number
}
console.log("------------多继承实例--------------");
interface Child extends IParent1, IParent2 { };
let Iobj: Child = { v1: 12, v2: 23 };           // 忽略这个error
console.log("value 1: " + Iobj.v1 + " value 2: " + Iobj.v2);            // value 1: 12 value 2: 23



// 
interface LabelledValue {
    label: string;
}
console.log("------------Demo--------------");
function printLabel(labelledObj: LabelledValue) {
    console.log(labelledObj.label);
}

let myObj = { size: 10, label: "Size 10 Object" };
printLabel(myObj);                  // Size 10 Object

// tsc --removeComments .\TS\TS_Interface.ts --outFile .\dict\TS_Interface.js
// node .\dict\TS_Interface.js
