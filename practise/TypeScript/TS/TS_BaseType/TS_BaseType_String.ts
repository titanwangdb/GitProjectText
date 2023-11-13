/*
    基础类型 Base type
    注意：TypeScript 和 JavaScript 没有整数类型
    string(字符串类型)       单引号（'）或双引号（"）表示字符串类型。反引号（`）来定义多行文本和内嵌表达式
*/

class BaseTypeString {
    test(): void {
        let name: string = "TypeScript";
        let years: number = 5;
        let words: string = `Hollo, Name is: '${name}' and Number is: "${years + 1}"`;

        console.log(words);         // Hollo，Name is: 'TypeScript' and Number is: "6"
        console.log(typeof words);  // string
    }
}

let baseTypeString = new BaseTypeString();
baseTypeString.test();

// tsc --removeComments .\TS\TS_BaseType\TS_BaseType_String.ts --outFile .\TS\TS_BaseType\TS_BaseType_String.js
// node .\TS\TS_BaseType\TS_BaseType_String.js
