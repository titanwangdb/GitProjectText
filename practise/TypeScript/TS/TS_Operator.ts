/*
    operator 运算符
*/

const global_x = 10;
const global_y = 12;
const global_a = "TypeScript";
const global_b = "World";

class DemoOperator {
    // 算术运算符 Arithmetic operator
    opArithmetic(): void {
        var x: number = 5;
        var y = 7;
        // +	加法
        console.log("x + y: " + (x + y));       // x + y: 12
        // -	减法
        console.log("y - x: " + (y - x));       // y - x: 2
        // *	乘法
        console.log("x * y: " + (x * y));       // x * y: 35
        // /	除法
        console.log("y / x: " + (y / x));       // y / x: 1.4
        // %	取模（余数）
        console.log("y % x: " + (y % x));       // y % x: 2
        // ++	自增	
        console.log("x++: " + (x++));           // x++: 5
        // --	自减
        console.log("x--: " + (x--));           // x--: 6
    }

    // 逻辑运算符 Logical operator
    opLogical(): void {
        // &&	and	
        // ||	or
        // !	not
    }

    // 关系运算符 Relational operator
    opRelational(): void {
        // ==	 等于
        // !=	 不等于
        // >	 大于
        // <	 小于
        // >=	 大于或等于
        // <=	 小于或等于
    }

    // 位运算符 Bitwise operator
    opBitwise(): void {
        // &	AND，按位与处理两个长度相同的二进制数，两个相应的二进位都为 1，该位的结果值才为 1，否则为 0。	x = 5 & 1	0101 & 0001	0001	 1
        // |	OR，按位或处理两个长度相同的二进制数，两个相应的二进位中只要有一个为 1，该位的结果值为 1。	x = 5 | 1	0101 | 0001	0101	 5
        // ~	取反，取反是一元运算符，对一个二进制数的每一位执行逻辑反操作。使数字 1 成为 0，0 成为 1。	x = ~ 5	 ~0101	1010	 -6
        // ^	异或，按位异或运算，对等长二进制模式按位或二进制数的每一位执行逻辑异按位或操作。操作的结果是如果某位不同则该位为 1，否则该位为 0。	x = 5 ^ 1	0101 ^ 0001	0100	 4
        // <<	左移，把 << 左边的运算数的各二进位全部左移若干位，由 << 右边的数指定移动的位数，高位丢弃，低位补 0。	x = 5 << 1	0101 << 1	1010	 10
        // >>	右移，把 >> 左边的运算数的各二进位全部右移若干位，>> 右边的数指定移动的位数。	x = 5 >> 1	0101 >> 1	0010	2
        // >>>	无符号右移，与有符号右移位类似，除了左边一律使用0 补位。	x = 2 >>> 1	0010 >>> 1	0001	1
    }

    // 赋值运算符 Assignment operator
    opAssignment(): void {
        // = (赋值)	x = y	x = y	x = 5
        // += (先进行加运算后赋值)	x += y	x = x + y	x = 15
        // -= (先进行减运算后赋值)	x -= y	x = x - y	x = 5
        // *= (先进行乘运算后赋值)	x *= y	x = x * y	x = 50
        // /= (先进行除运算后赋值)	x /= y	x = x / y	x = 2
    }

    // 三元运算符 Ternary operator
    operTernary(x: number, y: number): void {
        // Test ? expr1 : expr2
        var result = x > y ? x : y;
        console.log(result);
    }

    // 条件运算符 Conditional operator
    // operConditional(): void {  }

    // 字符串运算符     String operator
    operString(x: string, y:string): void {
        console.log(x + " " + y)
    }

    // 类型运算符   Type operator
    operType(x: any): void {
        console.log(typeof x);
    }
}

let oper = new DemoOperator();
oper.opArithmetic();
oper.operTernary(global_x, global_y);       // 12
oper.operString(global_a, global_b);        // TypeScript World
oper.operType(global_a);                    // string
oper.operType(global_x)                     // number

// tsc --removeComments .\TS\TS_Operator.ts --outFile .\dict\TS_Operator.js
// node .\dict\TS_Operator.js
