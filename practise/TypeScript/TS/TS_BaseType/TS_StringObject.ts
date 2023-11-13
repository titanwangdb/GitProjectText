/*
    String Object
*/

class DemoStringObject {
    testProperty(): void {
        // constructor  对创建该对象的函数的引用
        var str = new String("This is string");
        console.log("str.constructor is: " + str.constructor);  // str.constructor is: function String() { [native code] }

        // 	length      返回字符串的长度
        str = new String("Hello World");
        console.log("Length: " + str.length);             // 11
    }

    testMethod(): void {
        var str = new String("RUNOOB");
        var str2 = new String(" GOOGLE");

        // charAt()     返回在指定位置的字符
        console.log("charAt: " + str.charAt(0) + "," + str.charAt(1) + "," + str.charAt(2) + "," + str.charAt(3));    // charAt: R,U,N,O            // 82

        // charCodeAt() 返回在指定的位置的字符的 Unicode 编码
        console.log("charCodeAt: " + str.charCodeAt(0) + "," + str.charCodeAt(1) + "," + str.charCodeAt(2) + "," + str.charCodeAt(3));  // charCodeAt: 82,85,78,79               // 82

        // concat()     连接两个或更多字符串，并返回新的字符串
        console.log(str.concat(str2.toString()));                                // RUNOOB GOOGLE

        // indexOf()    返回某个指定的字符串值在字符串中首次出现的位置
        var index = str.indexOf("OO");
        console.log("indexOf: " + index);                                       // indexOf: 3

        // lastIndexOf() 从后向前搜索字符串，并从起始位置（0）开始计算返回字符串最后出现的位置
        var str1 = new String("This is string one and again string");
        index = str1.lastIndexOf("string");
        console.log("lastIndexOf: " + index);            // lastIndexOf: 29

        index = str1.lastIndexOf("one");
        console.log("lastIndexOf: " + index);            // lastIndexOf: 15

        // localeCompare()  用本地特定的顺序来比较两个字符串
        str1 = new String("This is beautiful string");
        index = str1.localeCompare("This is beautiful string");
        console.log("localeCompare: " + index);         // localeCompare: 0

        // match()  查找找到一个或多个正则表达式的匹配 
        str = "The rain in SPAIN stays mainly in the plain";
        console.log(str.match(/ain/g));                 // [ 'ain', 'ain', 'ain' ]

        // replace() 替换与正则表达式匹配的子串
        var re = /(\w+)\s(\w+)/;
        var str03 = "zara ali";
        console.log(str03.replace(re, "$2, $1"));      // ali, zara

        // search()     检索与正则表达式相匹配的值
        re = /round/gi;
        str03 = "Apples are round, and apples are juicy.";
        if (str03.search(re) == -1) {
            console.log("Does not contain Apples");
        } else {
            console.log("Contains Apples");             // Contains Apples
        }

        // slice()  提取字符串的片断，并在新的字符串中返回被提取的部分

        // split()  把字符串分割为子字符串数组
        console.log(str03.split(" ", 3))                        // [ 'Apples', 'are', 'round,' ]

        // substr() 从起始索引号提取字符串中指定数目的字符

        // substring()  提取字符串中两个指定的索引号之间的字符
        str03 = "RUNOOB GOOGLE TAOBAO FACEBOOK";
        console.log("(1,2): " + str03.substring(1, 2));          // (1,2): U
        console.log("(0,10): " + str03.substring(0, 10));        // (0,10): RUNOOB GOO
        console.log("(5): " + str03.substring(5));               // (5): B GOOGLE TAOBAO FACEBOOK

        // toLocaleLowerCase()   字符串转换为小写
        str03 = "Runoob Google";
        console.log(str03.toLocaleLowerCase());                // runoob google

        // toLocaleUpperCase()  字符串转换为大写
        console.log(str03.toLocaleUpperCase());                // RUNOOB GOOGLE

        // toLowerCase()    把字符串转换为小写
        console.log(str03.toLowerCase());                      // runoob google

        // toUpperCase()    把字符串转换为大写
        console.log(str03.toUpperCase());                      // RUNOOB GOOGLE

        // toString()       返回字符串
        console.log(str03.toString());                         // Runoob Google

        // valueOf()        返回指定字符串对象的原始值
        console.log(str03.valueOf());                          // Runoob Google
    }
}


let dso = new DemoStringObject();
console.log("----------testProperty-------------");
dso.testProperty();



console.log("----------prototype-------------");
// prototype    允许您向对象添加属性和方法
function employeeString(id: number, name: string) {
    this.id = id
    this.name = name
}
var emp = new employeeString(123, "admin")
employeeString.prototype.email = "admin@runoob.com"       // 添加属性 email

console.log("id: " + emp.id);                    // id: 123
console.log("name: " + emp.name);                // name: admin
console.log("email: " + emp.email);              // email: admin@runoob.com


console.log("----------testMethod-------------");
dso.testMethod();

// tsc --removeComments .\TS\TS_StringObject.ts --outFile .\dict\TS_StringObject.js
// node .\dict\TS_StringObject.js
