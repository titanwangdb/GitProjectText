/*
    基础类型 Base type
    注意：TypeScript 和 JavaScript 没有整数类型
    enum
*/

function BaseTypeEnum(){
    // 数字枚举
    enum Color {
        Red,
        Green,
        Blue,
    };
    let color: Color = Color.Blue;
    console.log("color: " + color);                 // color: 2
    console.log(typeof color);                      // number
     // 枚举编号
    console.log("Color.Blue: " + Color.Blue);       // Color.Blue: 2
    // 可以由枚举的值得到它的名字
    console.log("Color[0]: " + Color[0] + " Color[2]: " + Color[1]);    // Color[0]: Red Color[2]: Green

    // 元素编号手动赋值
    enum CustomColor {
        Red = 2,
        Green = 4,
        Blue = 6,
    };
    let customColor: CustomColor = CustomColor.Green;
    console.log("customColor: " + customColor);                                                 // customColor: 4
    console.log("CustomColor.Blue: " + CustomColor.Blue);                                       // customColor.Blue: 6 
    console.log("CustomColor[0]: " + CustomColor[2] + " CustomColor[2]: " + CustomColor[6]);    // CustomColor[0]: Red CustomColor[2]: Blue

    // 字符串枚举
    enum Direction {
        NORTH = "NORTH",
        SOUTH = "SOUTH",
        EAST = "EAST",
        WEST = "WEST",
    };
    let dire: Direction = Direction.SOUTH;
    console.log("dire: " + dire);                                                               // dire: SOUTH
    console.log("Direction.SOUTH: " + Direction.SOUTH);                                         // Direction.SOUTH: SOUTH
    // console.log("Direction[0]: " + Direction[0] + " Direction[2]: " + Direction[2]);            // undefined

    // 异构枚举, 异构枚举的成员值是数字和字符串的混合
    enum Enum {
        A,
        B,
        C = "C",
        D = "D",
        E = 8,
        F,
    }
    let en: Enum = Enum.A;
    console.log("en: " + en);                       // en: 0
    console.log("Enum.C: " + Enum.C);               // Enum.C: C
}

BaseTypeEnum();

// tsc --removeComments .\TS\TS_BaseType\TS_BaseType_Enum.ts --outFile .\TS\TS_BaseType\TS_BaseType_Enum.js
// node .\TS\TS_BaseType\TS_BaseType_Enum.js
