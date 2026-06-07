let date = new Date();
let age = 20;
console.log(typeof date)
console.log(date instanceof Date)
console.log(age instanceof Date);
let trainee1 = {};
trainee1.name = 'Ami';
trainee1.course = 'ESAD';
console.log(trainee1);
let trainee2 = {name:'Tumi', course: 'NT'};
console.log(trainee2);
let trainee3 = new Object();
trainee3.name = 'Shey';
trainee3.course = 'GAVE';
console.log(trainee3);
console.log(trainee1.hasOwnProperty('id'));
console.log(trainee1.hasOwnProperty('course'));
console.log();
const address = {
    country: 'Australia', 
    city: 'Sydney', 
    streetNum: '412',
    streetName: 'Worcestire Blvd'
};
for(const prop of Object.keys(address)){
    console.log(`${prop}: ${address[prop]}`)
}
console.log()
let obj = {};
if(Object.keys(obj).length==0){
    console.log('Empty object')
}
console.log();
const obj1 ={name: 'The name', age:25};
const obj2 = {contact:'01710XXXXXX'};
const person = {...obj1, ...obj2};
console.log(person)
Object.freeze(person);
person.name ='T Rex';
console.log(person)
