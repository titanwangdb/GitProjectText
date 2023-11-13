/*
    Tuple Object
*/

class DemoTupleObject {
    test(): void {
        var mytuple = [10, "Hello", "World", "typeScript"];

        // 返回元组的大小
        console.log("length：" + mytuple.length);           // length：4

        // 添加到元组中
        mytuple.push(12)
        console.log("length：" + mytuple.length);           // length：5

        // 删除并返回删除的元素
        console.log("pop: " + mytuple.pop())                // pop: 12
        console.log("length：" + mytuple.length);           // length：4

        // 更新元组元素
        console.log("mytuple[0]：" + mytuple[0]);           // mytuple[0]：10
        mytuple[0] = 121;
        console.log("mytuple[0]：" + mytuple[0]);           // mytuple[0]：121

        // 解构元组
        var a = [10, "Runoob"];
        var [b, c] = a;
        console.log(b);             // 10
        console.log(c);             // Runoob
    }
}

let dto = new DemoTupleObject();
dto.test();

// tsc --removeComments .\TS\TS_TupleObject.ts --outFile .\dict\TS_TupleObject.js
// node .\dict\TS_TupleObject.js
