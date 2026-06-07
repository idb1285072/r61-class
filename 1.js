let peopleFatso =[
    {name: 'Mota', weight:110, age: 29},
    {name: 'Bhotka', weight:130, age: 33},
    {name: 'Gama', weight:90, age: 19},
    {name: 'Ghot', weight:135, age: 35}
];
let sortfn = (f1, f2)=>{
    if(f1.weight == f2.weight) return 0;
    else if (f1.weight > f2.weight) return 1;
    else return -1;
}
peopleFatso.sort(sortfn).reverse().forEach(f=>console.log(f));
console.log();
peopleFatso.sort((f1, f2)=>{
    if(f1.weight == f2.weight) return 0;
    else if (f1.weight > f2.weight) return 1;
    else return -1;
}).reverse().forEach(f=>console.log(f));
console.log();
[8, 2, 5, 9, 7].map(n=> n*10**2).forEach(n=> console.log(n))
console.log();
function pow(number, power=1){
    return number**power
}
console.log(pow(7, 2));
console.log(pow(10));
console.log();
function sumUp (...numbers){
    let sum = 0;
    numbers.forEach(x=> sum += x);
    /* for(let i=0; i<numbers.length;i++){
        sum += numbers[i]
    } */
    return sum;
}
console.log(sumUp(10, 9, 12));
console.log();
let sumThree = ({firstNumber, secondNumber, thirdNumber})=>{
    return (firstNumber | 0)+(secondNumber | 0)+(thirdNumber |0);

}

console.log(sumThree({secondNumber:2, firstNumber:1,thirdNumber:3}));
console.log(sumThree({secondNumber:2,thirdNumber:3}));

function divide(number, parts){
    return getParts(number, parts);
    function getParts(n, p){
        let theParts =[];
        for(let i=0; i< p;i++){
            theParts.push((n*.98)/p);
        }
        return theParts;
    }
}
console.log(divide(20, 6));
console.log();
function* getRandomValues(){
    //let n = Math.floor(Math.random()*(100-10)+10)+1;
    yield 12;
    yield 10;
    yield 11;
    yield 9;
    
}
let generator = getRandomValues();
console.log(generator.next().value)
console.log(generator.next().value)
console.log(generator.next().value)
console.log(generator.next().value)
console.log(generator.next())
console.log();
for(let value of getRandomValues()){
    console.log(value)
}
console.log();
function factorial(n){
    if(n == 1) return 1;
    return n*factorial(n-1);
}
console.log(factorial(11));