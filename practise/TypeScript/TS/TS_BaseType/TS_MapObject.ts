/*
    Map Object
        Map 对象保存键值对，并且能够记住键的原始插入顺序。
        任何值(对象或者原始值) 都可以作为一个键或一个值。
        Map 是 ES6 中引入的一种新的数据结构
*/

class DemoMapObject {
    test(): void {
        // 创建 Map
        let nameSiteMapping = new Map();

        // map.set() – 设置键值对，返回该 Map 对象
        nameSiteMapping.set("Google", 11);
        nameSiteMapping.set("Runoob", 12);
        nameSiteMapping.set("Taobao", 13);

        // map.get() – 返回键对应的值，如果不存在，则返回 undefined
        console.log("get: " + nameSiteMapping.get("Runoob"));       // get: 12

        // map.has() – 返回一个布尔值，用于判断 Map 中是否包含键对应的值
        console.log("has: " + nameSiteMapping.has("Taobao"));       // has: true
        console.log("has: " + nameSiteMapping.has("Zhihu"));        // has: false

        // map.size – 返回 Map 对象键/值对的数量
        console.log("size: " + nameSiteMapping.size);                // size: 3

        // map.keys() - 返回一个 Iterator 对象， 包含了 Map 对象中每个元素的键
        for (let key of nameSiteMapping.keys()) {
            console.log(key);
        }
        // map.values() – 返回一个新的Iterator对象，包含了Map对象中每个元素的值 
        for (let value of nameSiteMapping.values()) {
            console.log(value);
        }

        // 迭代 Map 中的 key => value
        for (let entry of nameSiteMapping.entries()) {
            console.log(entry[0], entry[1]);
        }

        // 使用对象解析
        for (let [key, value] of nameSiteMapping) {
            console.log(key, value);
        }

        // map.delete() – 删除 Map 中的元素，删除成功返回 true，失败返回 false
        console.log("delete: " + nameSiteMapping.delete("Runoob")); // delete: true
        console.log("nameSiteMapping: " + nameSiteMapping);         // 

        // map.clear() – 移除 Map 对象的所有键/值对
        nameSiteMapping.clear();             // 清除 Map
        console.log("nameSiteMapping: " + nameSiteMapping);         //
    }
}

let dmo = new DemoMapObject();
dmo.test();

// tsc --removeComments .\TS\TS_MapObject.ts --outFile .\dict\TS_MapObject.js
// node .\dict\TS_MapObject.js
