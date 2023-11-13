/*
*/

// Demo01
// function hello(compiler: string) {
//     console.log(`Hello from ${compiler}`);
// }
// hello("TypeScript");


// 从 greet.ts 导入 function sayHello
import { sayHello } from "./greet";         
// import DvTest = require("./greet");
// from say.ts import  class say
//import { Say } from "./say";                

/*
    hello word
*/
// console.log(sayHello("TypeScript"));
//console.log(Say.sayHi("Hi"));



// /*
//     showHello调用sayHello函数更改页面上段落的文字
// */
function showHello(element: string, name: string) {
    const elementName = document.getElementById(element);
    elementName.innerText = sayHello(name);
}

showHello("greeting", "TypeScript");

// /*
//     showSay
// */
// function showSay(element: string, name: string) {
//     const elementName = document.getElementById(element);
//     elementName.innerText = Say.sayHi(name);
// }

// showSay("say", "TypeScript");