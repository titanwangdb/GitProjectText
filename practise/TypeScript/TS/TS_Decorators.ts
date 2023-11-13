/*
    Decorators  装饰器
        它是一个表达式
        该表达式被执行后，返回一个函数
        函数的入参分别为 target、name 和 descriptor
        执行该函数后，可能返回 descriptor 对象，用于配置 target 对象
*/

// 类装饰器（Class decorators）
function Greeter(greeting: string) {
    return function (target: Function) {
        target.prototype.greet = function (): void {
            console.log(greeting);
        };
    };
}

@Greeter("Hello TS!")
class Greeting {
    constructor() {
        // 内部实现
    }
}

let myGreeting = new Greeting();
myGreeting.greet(); // console output: 'Hello TS!';






// 属性装饰器（Property decorators）
function logProperty(target: any, key: string) {
    delete target[key];

    const backingField = "_" + key;

    Object.defineProperty(target, backingField, {
        writable: true,
        enumerable: true,
        configurable: true
    });

    // property getter
    const getter = function (this: any) {
        const currVal = this[backingField];
        console.log(`Get: ${key} => ${currVal}`);
        return currVal;
    };

    // property setter
    const setter = function (this: any, newVal: any) {
        console.log(`Set: ${key} => ${newVal}`);
        this[backingField] = newVal;
    };

    // Create new property with getter and setter
    Object.defineProperty(target, key, {
        get: getter,
        set: setter,
        enumerable: true,
        configurable: true
    });
}

class Person {
    @logProperty
    public name: string;

    constructor(name: string) {
        this.name = name;
    }
}

const p1 = new Person("semlinker");
p1.name = "kakuqo";





// 方法装饰器（Method decorators）
function LogOutput(tarage: Function, key: string, descriptor: any) {
    let originalMethod = descriptor.value;
    let newMethod = function (...args: any[]): any {
        let result: any = originalMethod.apply(this, args);
        if (!this.loggedOutput) {
            this.loggedOutput = new Array<any>();
        }
        this.loggedOutput.push({
            method: key,
            parameters: args,
            output: result,
            timestamp: new Date()
        });
        return result;
    };
    descriptor.value = newMethod;
}

class Calculator {
    @LogOutput
    double(num: number): number {
        return num * 2;
    }
}

let calc = new Calculator();
calc.double(11);
// console ouput: [{method: "double", output: 22, ...}]
console.log(calc.loggedOutput);


// 参数装饰器（Parameter decorators）
function Log(target: Function, key: string, parameterIndex: number) {
    let functionLogged = key || target.prototype.constructor.name;
    console.log(`The parameter in position ${parameterIndex} at ${functionLogged} has
      been decorated`);
}

class Greeter {
    greeting: string;
    constructor(@Log phrase: string) {
        this.greeting = phrase;
    }
}

// console output: The parameter in position 0
// at Greeter has been decorated



// tsc --removeComments .\TS\TS_Decorators.ts --outFile .\dict\TS_Decorators.js
// node .\dict\TS_Decorators.js
