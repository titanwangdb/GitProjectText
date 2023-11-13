/*
    Generics 泛型
        软件工程中，我们不仅要创建一致的定义良好的 API，同时也要考虑可重用性。 组件不仅能够支持当前的数据类型，同时也能支持未来的数据类型，这在创建大型系统时为你提供了十分灵活的功能。
        在像 C# 和 Java 这样的语言中，可以使用泛型来创建可重用的组件，一个组件可以支持多种类型的数据。 这样用户就可以以自己的数据类型来使用组件。
        设计泛型的关键目的是在成员之间提供有意义的约束，这些成员可以是：类的实例成员、类的方法、函数参数和函数返回值。
        泛型（Generics）是允许同一个函数接受不同类型参数的一种模板。相比于使用 any 类型，使用泛型来创建可复用的组件要更好，因为泛型会保留参数类型。
*/

// 泛型接口
interface GenericIdentityFn<T> {
    (arg: T): T;
}


// 泛型类
class GenericNumber<T> {
    zeroValue: T;
    add: (x: T, y: T) => T;
}

let genericNumber = new GenericNumber<number>();
genericNumber.zeroValue = 0;
genericNumber.add = function (x, y) {
    return x + y;
};

// 泛型变量
// T（Type）：表示一个 TypeScript 类型
// K（Key）：表示对象中的键类型
// V（Value）：表示对象中的值类型
// E（Element）：表示元素类型


// 泛型工具类型.typeof     typeof 操作符可以用来获取一个变量声明或对象的类型
interface Person {
    name: string;
    age: number;
}

const sem: Person = { name: 'semlinker', age: 30 };
type Sem = typeof sem;                      // -> Person
// console.log(Sem);

function toArray(x: number): Array<number> {
    return [x];
}

type Func = typeof toArray;                 // -> (x: number) => number[]

// 泛型工具类型.keyof      keyof 操作符可以用来一个对象中的所有 key 值：
interface Person {
    name: string;
    age: number;
}

type K1 = keyof Person;                     // "name" | "age"
type K2 = keyof Person[];                   // "length" | "toString" | "pop" | "push" | "concat" | "join" 
type K3 = keyof { [x: string]: Person };    // string | number

// 泛型工具类型.in          用来遍历枚举类型
type Keys = "a" | "b" | "c"

type Obj = {
    [p in Keys]: any
}                                           // -> { a: any, b: any, c: any }

// 泛型工具类型.infer       在条件类型语句中，可以用 infer 声明一个类型变量并且对它进行使用
type ReturnTypeX<T> = T extends (
    ...args: any[]
) => infer R ? R : any;     // infer R 就是声明一个变量来承载传入函数签名的返回值类型，简单说就是用它取到函数返回值的类型方便之后使用。

// 泛型工具类型.extends     有时候我们定义的泛型不想过于灵活或者说想继承某些类等，可以通过 extends 关键字添加泛型约束
interface ILengthwise {
    length: number;
}

function loggingIdentity<T extends ILengthwise>(arg: T): T {
    console.log(arg.length);
    return arg;
}

loggingIdentity({ length: 10, value: 3 });

// 泛型工具类型.Partial         Partial<T> 的作用就是将某个类型里的属性全部变为可选项 ?
interface Todo {
    title: string;
    description: string;
}

function updateTodo(todo: Todo, fieldsToUpdate: Partial<Todo>) {
    return { ...todo, ...fieldsToUpdate };
}

const todo1 = {
    title: "organize desk",
    description: "clear clutter",
};

const todo2 = updateTodo(todo1, {
    description: "throw out trash",
});



// tsc --removeComments .\TS\TS_Generics.ts --outFile .\dict\TS_Generics.js
// node .\dict\TS_Generics.js
