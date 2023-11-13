/*
    Number 对象
*/

class DemoNumberObject {
    testProperty(): void {
        // MAX_VALUE 可表示的最大的数，MAX_VALUE 属性值接近于 1.79E+308。大于 MAX_VALUE 的值代表 "Infinity"
        console.log("MAX_VALUE: " + Number.MAX_VALUE);                      // MAX_VALUE: 1.7976931348623157e+308

        // MIN_VALUE 可表示的最小的数，即最接近 0 的正数 (实际上不会变成 0)。最大的负数是 -MIN_VALUE，MIN_VALUE 的值约为 5e-324。小于 MIN_VALUE ("underflow values") 的值将会转换为 0。
        console.log("MIN_VALUE: " + Number.MIN_VALUE);                      // MIN_VALUE: 5e-324

        // NEGATIVE_INFINITY 负无穷大，溢出时返回该值。该值小于 MIN_VALUE。
        console.log("NEGATIVE_INFINITY: " + Number.NEGATIVE_INFINITY);      // NEGATIVE_INFINITY: -Infinity

        // POSITIVE_INFINITY 正无穷大，溢出时返回该值。该值大于 MAX_VALUE。	
        console.log("POSITIVE_INFINITY: " + Number.POSITIVE_INFINITY);       // POSITIVE_INFINITY: Infinity

        // NaN 非数字值（Not-A-Number）
        let year = Number.NaN;
        console.log("Number.NaN: " + Number.NaN);                           // Number.NaN: NaN
        console.log("year: " + year);                                       // year: NaN

        // constructor 返回对创建此对象的 Number 函数的引用
    }

    testMethod(): void {
        // toExponential()  把对象的值转换为指数计数法。
        var num = 1225.30;
        console.log(num.toExponential());                    // 1.2253e+3

        // toFixed()    把数字转换为字符串，并对小数点指定位数
        num = 177.234;
        console.log("num.toFixed(): " + num.toFixed() + ", " + typeof num.toFixed());      // num.toFixed(): 177, string
        console.log("num.toFixed(2): " + num.toFixed(2));    // num.toFixed(2): 177.23
        console.log("num.toFixed(6): " + num.toFixed(6));    // num.toFixed(6): 177.234000

        // 	toLocaleString()    把数字转换为字符串，使用本地数字格式顺序
        var num02 = new Number(177.1234);
        console.log(typeof num02 + "," + num02);                                                    // object,177.1234
        console.log(num02.toLocaleString() + "," + typeof num02.toLocaleString());                  // 177.123,string

        // toPrecision()        把数字格式化为指定的长度
        num02 = new Number(7.123456);
        console.log(num02.toPrecision() + " " + num02.toPrecision(1) + " " + num02.toPrecision(2));        // 7.123456   7   7.1

        // toString()           把数字转换为字符串，使用指定的基数。数字的基数是 2 ~ 36 之间的整数。若省略该参数，则使用基数 10
        num02 = new Number(10);
        console.log(num02.toString());                      // 10进制：10
        console.log(num02.toString(2));                     // 2进制：1010
        console.log(num02.toString(8));                     // 8进制：12

        // valueOf()            返回一个 Number 对象的原始数字值
        num02 = new Number(10);
        console.log(num02.valueOf() + ", " + typeof num02);                       // 10, 
    }
}

let dn = new DemoNumberObject();
console.log("--------------testProperty-----------------");
dn.testProperty();



console.log("--------------prototype-----------------");
// prototype  Number对象的静态属性。使您有能力向对象添加属性和方法
function employeeNumber(id: number, name: string) {
    this.id = id;
    this.name = name;
}

var emp = new employeeNumber(123, "admin");
employeeNumber.prototype.email = "admin@runoob.com";       // 添加属性 email

console.log("id: " + emp.id);
console.log("name: " + emp.name);
console.log("email: " + emp.email);




console.log("--------------testMethod-----------------");
dn.testMethod();


// tsc --removeComments .\TS\TS_NumberObject.ts --outFile .\dict\TS_NumberObject.js
// node .\dict\TS_NumberObject.js
