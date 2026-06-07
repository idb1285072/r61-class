let data = {id: 33, name: 'Habib', grade: 'C', rank: 5};
const {name, rank} = data;
console.log(name, rank); 

let names = ['Dhaka', 'Chittgong', 'Barishal', 'Noakhali', 'Chandpur'];
const [dhk, ctg,,,cpr] = names;
console.log(ctg)
const [d, c,...others]=names;
console.log(d, c, others);
let numbers = [23, 9, 11, 17, 13, 19];
console.log(Math.max(...numbers));
numbers.length=0;