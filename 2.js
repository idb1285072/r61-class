let str = 'Mafuluz, Aslam, Kismat, Khan';
let names = str.split(',');
names.forEach((n, i)=>{
console.log(i, n.trim())
});
let anotherString = 'My favorite fruits: Mango, Lichie, Kadol, Anarosh, Pepe.';
let start = anotherString.indexOf(':');
let end = anotherString.indexOf('.');
let fStr = anotherString.slice(start+1, end).trim();
let fruits = fStr.split(', ');
fruits.forEach(f=>console.log(f));