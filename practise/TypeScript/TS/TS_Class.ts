/*
    Class 类
        访问控制修饰符
            public（默认）: 公有，可以在任何地方被访问
            protected: 受保护，可以被其自身以及其子类访问
            private: 私有，只能被其定义所在的类访问
*/


// 
class Person {
}

console.log("--------Person----------");
let person = new Person();
// instanceof 运算符
var isPerson = person instanceof Person;
console.log("person is Person? " + isPerson);       // person is Person? true


let passcode = "Hello TypeScript";
// 完整实例
class Car {
    // 字段 
    engine: string;
    // 静态 字段
    static static_num: number;          // static 关键字, 用于定义类的数据成员（属性和方法）为静态的，静态成员可以直接通过类名调用
    //
    private _fullName: string;
    // 私有字段
    // #privateName: string;            // 以 # 字符开头

    // 构造函数 
    constructor(engine: string) {
        this.engine = engine;
    }

    // 方法 
    disp(): void {
        console.log("engine: " + this.engine);
    }
    // 静态 方法 
    static staticDisp(): void {
        console.log("static_num: " + Car.static_num);
    }
    // 函数重载, 定义了四个重载方法
    add(a: number, b: number): number;
    add(a: string, b: string): string;
    add(a: string, b: number): string;
    add(a: number, b: string): string;
    add(a: any, b: any) {
        if (typeof a === "string" || typeof b === "string") {
            return a.toString() + b.toString();
        }
        return a + b;
    }
    // 
    // greet() {
    //     console.log(`Hello, my name is ${this.#privateName}!`);
    // }

    // get 访问器
    get fullName(): string {
        return this._fullName;
    }
    // set 访问器
    set fullName(newName: string) {
        if (passcode && passcode == "Hello TypeScript") {
            this._fullName = newName;
        } else {
            console.log("Error: Unauthorized update of employee!");
        }
    }
}

console.log("--------Car----------");
// 创建对象
let car = new Car("car.engind");
// 访问字段
console.log("engine is: " + car.engine);        // engine is: car.engind
// 访问方法
car.disp();             // engine: car.engind                
// car.greet();
// 初始化静态变量
Car.static_num = 2020;
// 调用静态方法
Car.staticDisp();       // static_num: 2020
// 访问器
car.fullName = "Semlinker";
if (car.fullName) {
    console.log(car.fullName);      // Semlinker
}





// Inheritance 类的继承, 子类只能继承一个父类，TypeScript 不支持继承多个类，但支持多重继承
class Shape {
    Area: number;

    constructor(area: number) {
        this.Area = area;
    }
}

class Circle extends Shape {
    disp(): void {
        console.log("Area: " + this.Area);
    }
}
console.log("--------类的继承----------");
var circle = new Circle(2020);
circle.disp();                  // Area: 2020

// 多重继承
class Root {
    str: string;
}

class Child extends Root { }
class Leaf extends Child { }    // 多重继承，继承了 Child 和 Root 类
console.log("--------多重继承----------");
var leaf = new Leaf();
leaf.str = "hello";
console.log("leaf: " + leaf.str);       // leaf: hello

// 继承类的方法重写
class PrinterClass {
    doPrint(): void {
        console.log("Base.doPrint()");
    }
}

class StringPrinter extends PrinterClass {
    doPrint(): void {
        // super 关键字是对父类的直接引用，该关键字可以引用父类的属性和方法
        super.doPrint()                 // 调用父类的函数
        console.log("Child.doPrint()");
    }
}
console.log("--------继承类的方法重写----------");
let stringPrinter = new StringPrinter();
stringPrinter.doPrint();                    // Base.doPrint()   Child.doPrint()




// 类和接口, 类可以实现接口，使用关键字 implements，并将 interest 字段作为类的属性使用
interface ILoan {
    interest: number
}

class AgriLoan implements ILoan {
    interest: number;
    rebate: number;

    constructor(interest: number, rebate: number) {
        this.interest = interest;
        this.rebate = rebate;
    }
}
console.log("--------ILoan and AgriLoan----------");
var obj = new AgriLoan(10, 1);
console.log("interest: " + obj.interest + ", rebate: " + obj.rebate);       // interest: 10, rebate: 1


// tsc --removeComments .\TS\TS_Class.ts --outFile .\dict\TS_Class.js
// node .\dict\TS_Class.js
