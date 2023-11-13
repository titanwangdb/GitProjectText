/*
    基础类型 Base type
    注意：TypeScript 和 JavaScript 没有整数类型
    array(数组类型)
*/

class BaseTypeArray {
    test(): void {
        // Array<string> 之间有什么区别？和 string[] ？      -- 两者没有区别，都是一样的
        let sites: string[];
        sites = ["Google", "Runoob", "Taobao"];
        console.log("sites: " + sites);             // sites: Google,Runoob,Taobao
        console.log("sites[0]: " + sites[0]);       // sites[0]: Google
        console.log("sites[1]: " + sites[1]);       // sites[1]: Runoob

        let arrayA: number[] = [0, 1, 2];
        // 数组遍历
        for (let x in arrayA) {
            console.log(arrayA[x])          // 0 1 2
        }
        // 数组遍历
        for (let x of arrayA) {
            console.log(x)                  // 0 1 2
        }
        console.log("arrayA[0]: " + arrayA[0]);     // arrayA[0]: 0

        let arrayList: any[] = [1, false, 'fine'];  // 定义 Object 数组
        arrayList[1] = 100;
        console.log("arrayList: " + typeof arrayList);   // arrayList: object

        // 数组泛型
        let arrayX: Array<object> = [];
        console.log("arrayX: " + typeof arrayX);    // arrayX: object
        let arrayB: Array<number> = [1, 2];
        console.log("arrayB[0]: " + arrayB[0]);     // arrayB[0]: 1

        var sites02: string[] = new Array("Google", "Runoob", "Taobao", "Facebook");
        for (let x in sites02) {
            console.log(sites02[x])                  // Google Runoob Taobao Facebook 
        }

        // 解构数组
        let [x, y, z] = sites;
        console.log(x + " " + y + " " + z);         // Google Runoob Taobao
    }
}

let baseTypeArray = new BaseTypeArray();
baseTypeArray.test();

// tsc --removeComments .\TS\TS_BaseType\TS_BaseType_Array.ts --outFile .\TS\TS_BaseType\TS_BaseType_Array.js
// node .\TS\TS_BaseType\TS_BaseType_Array.js
