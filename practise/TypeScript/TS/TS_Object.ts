/*
    Object 对象
        对象是包含一组键值对的实例
*/

namespace ts.Object {
    var sites = {
        site1: "Runoob",
        site2: "Google",
        sayHello: function () { }   // 类型模板
    };

    // 访问对象的值
    console.log(sites.site1);       // Runoob
    console.log(sites.site2);       // Google

    //  
    sites.sayHello = function () { return "hello"; }
    console.log(sites.sayHello());  // hello

    // function displayX(): string {
    //     return "AAA";
    // }
    // let { "AA", "BB", displayX()} = sites;

    //
    let personObj = {
        name: "Semlinker",
        gender: "Male",
    };
    // 组装对象
    let { name, gender } = personObj;
}




// tsc --removeComments .\TS\TS_Object.ts --outFile .\dict\TS_Object.js
// node .\dict\TS_Object.js
