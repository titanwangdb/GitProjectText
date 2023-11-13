/*
    条件语句 Conditional statement
*/

class DemoConditionalStatement {
    test(): void {
        let num: number = 5
        if (num > 0) {
            console.log(num)
        }

        if (num % 2 == 0) {
            console.log("Even number");     // 偶数
        }
        else {
            console.log("Odd number");      // 奇数
        }


        if (num == 0) {
            console.log("Zero");
        }
        else if (num % 2 == 0) {
            console.log("Even number");     // 偶数
        }
        else {
            console.log("Odd number");      // 奇数
        }

        let grade: string = "A";
        switch (grade) {
            case "A": {
                console.log("A");
                break;
            }
            case "B": {
                console.log("B");
                break;
            }
            case "C": {
                console.log("C");
                break;
            }
            case "D": {
                console.log("D");
                break;
            }
            default: {
                console.log("error");
                break;
            }
        }
    }
}

let cs = new DemoConditionalStatement();
cs.test();

// tsc --removeComments .\TS\TS_ConditionalStatement.ts --outFile .\dict\TS_ConditionalStatement.js
// node .\dict\TS_ConditionalStatement.js
