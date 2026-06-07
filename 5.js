let numbers = [21, 19, 23, 17, 25, 13, 29];
let sorted =numbers.sort();
numbers.forEach(n=>console.log(n));
let people = [
    {name:'Gorib', age: 23},
    {name:'Khairati', age: 43},
    {name:'Miskin', age: 19}
];
people.sort((p1, p2)=>{
    if(p1.age == p2.age) return 0;
    else if(p1.age>p2.age) return 1;
    else return -1;
}).forEach(x=> console.log(x.name, x.age));

numbers.map(n=> n+10).forEach(n=>console.log(n));
people.map(p=> {
    p.age = p.age+10;
    return p;
}).forEach(x=>console.log(x))
