/*
    循环 Loop
*/

class DemoLoop {
    // for 循环
    textFor(count: number): void {
        for (let x = 0; x < count; x++) {
            console.log(x)
        }
    }

    // for...in 循环
    testForIn(keys: any): void {
        for (let k in keys) {
            console.log(keys[k])
        }
    }

    // for...of 循环
    testForOf(keys: any): void {
        for (let k of keys) {
            console.log(k);
        }
    }

    // forEach 循环
    testForEach(keys: any): void {
        keys.forEach((val, idx, array) => {
            console.log("val: " + val + " idx: " + idx + " array: " + array);       // val: 当前值 idx：当前index array: Array
        });
    }

    // every 循环
    testEvery(keys: any): void {
        keys.every((val, idx, array) => {
            if (val <= 5) {
                console.log("val: " + val + " idx: " + idx + " array: " + array);       // val: 当前值 idx：当前index array: Array
                return true;    // Continues
            } else {
                return false;   // quit the iteration
            }
            // console.log("val: " + val + " idx: " + idx + " array: " + array);       // val: 当前值 idx：当前index array: Array
            // return true; 
            // Return false will 
        });
    }

    // while 循环
    testWhile(count: number): void {
        while (count >= 1) {
            console.log(count);
            count--;
        }
    }

    // do...while 循环
    testDoWhile(count: number): void {
        do {
            console.log(count);
            count--;
        } while (count >= 3);
    }
}

let dl = new DemoLoop();
dl.textFor(3);          // 0 1 2

// let keys: any = "a b c";
let array_str: Array<string> = ["a", "b", "c"];
dl.testForIn(array_str);     // a b c

let arrays = [1, "string", false];
dl.testForOf(arrays);     // 1 string false

let list = [4, 5, 6];
// val: 4 idx: 0 array: 4,5,6
// val: 5 idx: 1 array: 4,5,6
// val: 6 idx: 2 array: 4,5,6
dl.testForEach(list);

// val: 4 idx: 0 array: 4,5,6
// val: 5 idx: 1 array: 4,5,6
dl.testEvery(list);

let count = 5;
dl.testWhile(count);        // 5 4 3 2 1 

dl.testDoWhile(count);      // 5 4 3
// tsc --removeComments .\TS\TS_Loop.ts --outFile .\dict\TS_Loop.js
// node .\dict\TS_Loop.js
