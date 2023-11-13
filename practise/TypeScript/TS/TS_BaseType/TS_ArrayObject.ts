/*
    Array Object
*/

class DemoArrayObject {
    test(): void {
        let arr_names: number[] = new Array(4);
        for (let i = 0; i < arr_names.length; i++) {
            arr_names[i] = i * 2;
            console.log(arr_names[i]);           // 0 2 4 6 
        }

        let sites: string[] = new Array("Google", "Runoob", "Taobao", "Facebook");
        for (let i = 0; i < sites.length; i++) {
            console.log(sites[i]);               // Google Runoob Taobao Facebook
        }

        // 数组解构
        let arr: number[] = [12, 13, 14];
        let [x, y, z] = arr;            // 将数组的两个元素赋值给变量 x 和 y, z
        console.log(x);             // 12
        console.log(y);             // 13

        // 数组迭代
        var nums: number[] = [1001, 1002, 1003, 1004];
        for (let x in nums) {
            console.log(nums[x]);   // 1001 1002 1003 1004
        }

        // 多维数组
        var multi: number[][] = [[1, 2, 3], [23, 24, 25]];
        console.log(multi[0][0]);       // 1
        console.log(multi[0][1]);       // 2
        console.log(multi[0][2]);       // 3
        console.log(multi[1][0]);       // 23
        console.log(multi[1][1]);       // 24
        console.log(multi[1][2]);       // 25

        // 数组展开运算符
        let two_array = [0, 1];
        let five_array = [...two_array, 2, 3, 4];
        console.log("five_array: " + five_array);   // five_array: 0,1,2,3,4

        // ...语法 创建 剩余变量
        let [first, ...rest] = [1, 2, 3, 4];
        console.log("first: " + first);                     // first: 1
        console.log("rest: " + rest);                       // rest: 2,3,4

        // ReadonlyArray<T> 类型, 数组创建后再也不能被修改
        let a: number[] = [1, 2, 3, 4];
        let readonlyArray: ReadonlyArray<number> = a;
        // readonlyArray[0] = 10;       // 不允许修改
        console.log(readonlyArray);     // [ 1, 2, 3, 4 ]
    }

    testMethod(key: string): void {
        let alpha = ["a", "b", "c"];
        let numeric = [1, 2, 3];
        let numeric02 = [11, 12, 13];
        let array_num = [12, 5, 8, 130, 44];
        let array_sum: number[] = [0, 1, 2, 3];

        let array_str = new Array("Google", "Runoob", "Taobao");
        let array_slice = ["orange", "mango", "banana", "sugar", "tea"];

        function isBigEnough(element, index, array) {
            return (element >= 10);
        }

        switch (key) {
            case "concat":      // concat()     连接两个或更多的数组，并返回结果
                console.log("concat: " + numeric.concat(numeric02));        // concat: 1,2,3,11,12,13
                break;
            case "every":       // every()      检测数值元素的每个元素是否都符合条件
                console.log("every: " + array_num.every(isBigEnough));      // every: false
                break;
            case "filter":      // filter()     检测数值元素，并返回符合条件所有元素的数组
                console.log("filter: " + array_num.filter(isBigEnough));    // filter: 12,130,44
                break;
            case "forEach":     // forEach()    数组每个元素都执行一次回调函数
                array_num.forEach(function (value) {
                    console.log(value);                                     // 12 5 8 130 44
                });
                break;
            case "indexOf":     // indexOf()    搜索数组中的元素，并返回它所在的位置。 如果搜索不到，返回值 -1
                console.log("indexOf: " + array_num.indexOf(8));            // indexOf: 2
                break;
            case "join":            // join() 把数组的所有元素放入一个字符串
                console.log("join: " + array_str.join());                  // join: Google,Runoob,Taobao
                console.log("join: " + array_str.join(", "));              // join: Google, Runoob, Taobao
                console.log("join: " + array_str.join(" + "));             // join: Google + Runoob + Taobao
                break;
            case "lastIndexOf":    // lastIndexOf() 返回一个指定的字符串值最后出现的位置，在一个字符串中的指定位置从后向前搜索。
                console.log("lastIndexOf: " + array_num.lastIndexOf(8));    // lastIndexOf: 2
                break;
            case "map":        // map()    通过指定函数处理数组的每个元素，并返回处理后的数组
                console.log("map: " + array_num.map(Math.sqrt));            // 1,2,3
                break;
            case "pop":        // pop()   删除数组的最后一个元素并返回删除的元素
                console.log("Array: " + array_num);             // 12, 5, 8, 130, 44
                console.log("pop: " + array_num.pop());         // pop: 44
                console.log("pop: " + array_num.pop());         // pop: 130
                break;
            case "push":    // push()  向数组的末尾添加一个或更多元素，并返回新的长度
                console.log("Array: " + array_num);             // 12, 5, 8, 130, 44
                console.log("push: " + array_num.push(10));     // push: 6
                console.log("Array: " + array_num);             // 12, 5, 8, 130, 44, 10
                console.log("push: " + array_num.push(20));     // push: 7
                console.log("Array: " + array_num);             // 12, 5, 8, 130, 44, 10, 20
                break;
            case "reduce":    // reduce()    将数组元素计算为一个值（从左到右
                let totalReduce = array_sum.reduce(function (a, b) { return a + b; });
                console.log("reduce: " + totalReduce);                  // reduce: 6
                break;
            case "reduceRight":    // reduceRight()   将数组元素计算为一个值（从右到左）
                let totalReduceRight = array_sum.reduceRight(function (a, b) { return a + b; });
                console.log("reduceRight: " + totalReduceRight);        // reduceRight: 6
                break;
            case "reverse":    // reverse()   反转数组的元素顺序
                console.log("Reversed: " + array_num.reverse());        // Reversed: 44,130,8,5,12
                break;
            case "shift":    // shift()     删除并返回数组的第一个元素
                console.log("shift: " + array_num.shift());             // shift: 12
                break;
            case "slice":    // slice()     选取数组的的一部分，并返回一个新数组
                console.log("arr.slice( 1, 2): " + array_slice.slice(1, 2));    // arr.slice( 1, 2): mango
                console.log("arr.slice( 1, 3): " + array_slice.slice(1, 3));    // arr.slice( 1, 3): mango,banana
                break;
            case "some":    // some()      检测数组元素中是否有元素符合指定条件
                console.log("some: " + [2, 5, 8, 1, 4].some(isBigEnough));    // some: false
                console.log("some: " + [12, 5, 8, 1, 4].some(isBigEnough));   // some: true
                break;
            case "sort":        // sort()      对数组的元素进行排序
                console.log("sort: " + array_slice.sort());             // sort: banana,mango,orange,sugar,tea
                break;
            case "splice":    // splice()    从数组中添加或删除元素
                var arr = ["orange", "mango", "banana", "sugar", "tea"];
                var removed = arr.splice(2, 0, "water");
                console.log("After adding 1: " + arr);      // After adding 1: orange,mango,water,banana,sugar,tea
                console.log("removed is: " + removed);      // removed is:
                removed = arr.splice(3, 1);
                console.log("After removing 1: " + arr);    // After removing 1: orange,mango,water,sugar,tea
                console.log("removed is: " + removed);      // removed is: banana
                break;
            case "toString":     // toString()  把数组转换为字符串，并返回结果。
                console.log("toString: " + array_str.toString());  // toString: Google,Runoob,Taobao
                break;
            case "unshift":    // unshift()   向数组的开头添加一个或更多元素，并返回新的长度
                var array_unshift = array_slice.unshift("water");
                console.log("array_slice: " + array_slice);         // array_slice: water,orange,mango,banana,sugar,tea
                console.log("Length: " + array_unshift);            // Length: 6
                break;
            default:
                break;
        }
    }
}

let dao = new DemoArrayObject();
console.log("---------test----------");
dao.test();

console.log("---------testMethod----------");
let array_method: string[] = ["concat", "every", "filter", "forEach", "indexOf", "join", "lastIndexOf", "map", "pop", "push", "reduce", "reduceRight", "reverse", "shift", "slice", "some", "sort", "splice", "toString", "unshift"];
for (let x in array_method) {
    console.log("-----" + array_method[x] + "-----");
    dao.testMethod(array_method[x]);
}


// tsc --removeComments .\TS\TS_ArrayObject.ts --outFile .\dict\TS_ArrayObject.js
// node .\dict\TS_ArrayObject.js
