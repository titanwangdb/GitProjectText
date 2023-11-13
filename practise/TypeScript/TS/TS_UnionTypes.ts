/*
    Union Types 联合类型
        联合类型（Union Types）可以通过管道(|)将变量设置多种类型，赋值时可以根据设置的类型来赋值。
        注意：只能赋值指定的类型，如果赋值其它类型就会报错
*/

// 
console.log("------------------------");
let val: string | number;
val = 12;
console.log("val: " + val);                 // val: 12
val = "Runoob"
console.log("val: " + val);                 // val: Runoob

// 
function UnionTypesDisp(name: string | string[]) {
    if (typeof name == "string") {
        console.log(name);
    } else {
        for (let i = 0; i < name.length; i++) {
            console.log(name[i]);
        }
    }
}
console.log("-----------UnionTypesDisp-------------");
UnionTypesDisp("Runoob");                                         // Runoob
UnionTypesDisp(["Runoob", "Google", "Taobao", "Facebook"]);       // Runoob Google Taobao Facebook




console.log("-----------联合类型数组-------------");
// 联合类型数组
let arr: number[] | string[];
let i: number;
arr = [1, 2, 4];
for (i = 0; i < arr.length; i++) {
    console.log(arr[i]);                        // 1 2 4
}
arr = ["Runoob", "Google", "Taobao"];
for (i = 0; i < arr.length; i++) {
    console.log(arr[i]);                        // Runoob Google Taobao
}





// 通常与 null 或 undefined 一起使用
const sayHello = (name: string | undefined) => {
    if (typeof name === "string") {
        console.log("is string");
    } else if (typeof name === "undefined") {
        console.log("is undefined");
    } else {
        console.log("else");
    }
};
console.log("-----------undefined-------------");
sayHello("Semlinker");              // is string
sayHello(undefined);                // is undefined




// 可辨识联合 Discriminated Unions, 包含 3 个要点：可辨识、联合类型和类型守卫
enum CarTransmission {
    Automatic = 200,
    Manual = 300
}

interface IMotorcycle {
    vType: "motorcycle";            // 可辨识的属性
    make: number;
}

interface ICar {
    vType: "car";                   // 可辨识的属性
    transmission: CarTransmission
}

interface ITruck {
    vType: "truck";                 // 可辨识的属性
    capacity: number;
}

// 联合类型
type IVehicle = IMotorcycle | ICar | ITruck;

//类型守卫
const EVALUATION_FACTOR = Math.PI;

function evaluatePrice(vehicle: IVehicle) {
    switch (vehicle.vType) {
        case "car":
            console.log("this is car");
            return vehicle.transmission * EVALUATION_FACTOR;
        case "truck":
            console.log("this is truck");
            return vehicle.capacity * EVALUATION_FACTOR;
        case "motorcycle":
            console.log("this is motorcycle");
            return vehicle.make * EVALUATION_FACTOR;
    }
}

console.log("-----------Discriminated Unions-------------");
const myTruck: ITruck = { vType: "truck", capacity: 9.5 };
evaluatePrice(myTruck);             // this is truck





// 类型别名 Type Alias, 用来给一个类型起个新名字
type Message = string | string[];
let greet = (message: Message) => {
    if (typeof message === "string") {
        console.log("is string");
    } else if (typeof message === "object") {
        console.log("is object");
    } else {
        console.log("else");
    }
};

console.log("-----------Type Alias-------------");
greet("abc");                   // is string
greet(["a", "b"]);              // is object



// 交叉类型 Cross type, 将多个类型合并为一个类型。 这让我们可以把现有的多种类型叠加到一起成为一种类型，它包含了所需的所有类型的特性

console.log("-----------Cross Type-------------");





// tsc --removeComments .\TS\TS_UnionTypes.ts --outFile .\dict\TS_UnionTypes.js
// node .\dict\TS_UnionTypes.js
