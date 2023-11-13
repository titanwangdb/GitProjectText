/*
    JSON 
*/

interface IRoot {
    userId: number
    title: string
}

let rootObj: IRoot = JSON.parse('{ "userId": 2020, "title": "title" }');
console.log(rootObj + ", " + typeof rootObj);               // [object Object], object
console.log(rootObj.userId + " " + rootObj.title);          // 2020 title

// 
let employeeObj = '{ "name": "Franc", "department": "sales", "salary": 5000 }';
let jsonObject = JSON.parse(employeeObj);
console.log(jsonObject);                                // { name: 'Franc', department: 'sales', salary: 5000 }
console.log(jsonObject.name + ", " + jsonObject.department + ", " + jsonObject.salary);     // Franc, sales, 5000






// tsc --removeComments .\TS\TS_JSON.ts --outFile .\dict\TS_JSON.js
// node .\dict\TS_JSON.js
