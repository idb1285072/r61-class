let randomNumbers = [32, 47, 14, 20, 37, 65, 49, 69, 70];
randomNumbers.forEach((n, i)=>console.log(i, n));
console.log();
randomNumbers.push(22);
randomNumbers.unshift(57);
randomNumbers.forEach((n, i)=>console.log(i, n));
console.log()
randomNumbers.pop();
randomNumbers.shift();
randomNumbers.forEach((n, i)=>console.log(i, n));
console.log();
let newArray = randomNumbers.concat([55, 66]);
newArray.forEach((n, i)=>console.log(i, n));
console.log();
randomNumbers.splice(3, 2);
randomNumbers.forEach((n, i)=>console.log(i, n));
console.log();
let anotherArray = [12, ...randomNumbers, 21,...[1,2]];
anotherArray.forEach((n, i)=>console.log(i, n));
console.log();
let odds = randomNumbers.filter(n=> n%2!=0);
odds.forEach((n, i)=>console.log(i, n));
console.log();
let over50= randomNumbers.find(n=> n>50);
if(over50) console.log(over50)
console.log();
let i = randomNumbers.findIndex(n=> n==69);
if(i>=0){
    console.log(i);
    console.log(randomNumbers[i]);
}

