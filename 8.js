let date = new Date();
console.log(date.toUTCString())
console.log(date.getFullYear());
console.log(date.getMonth())
console.log(date.getDate())
console.log(date.getHours())
console.log(date.getMinutes())
console.log(date.getSeconds())
let myDate = new Date(1971, 11, 21);
console.log(myDate.toString());
date.setDate(3);
date.setMonth(4-1);
console.log(date.toString());
myDate.setDate(myDate.getDate()-10);
console.log(myDate.toString());