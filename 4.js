let data = [21, 23, 21, 47, 33, 24, 23];

//let uniqueValues =Array.from(new Set(data));
let uniqueValues =[...new Set(data)];
uniqueValues.forEach(v=>console.log(v))
console.log();
let cities =[
    ['Dhaka', 'Barishal', 'Noakhali'],
    ['Calcutta', 'Delhi'],
    ['London', 'Bristol', 'Yorkshire'],
    ['New York', 'Carolina', 'Las Vegus']
];
let allCities = cities.flat();
console.log(allCities);
allCities.forEach(c=> console.log(c));
let names = [
    'Gorib', 
    'Nimono', 
    'Miskin', 
    'Faquire', 
    'Khairati',
    'Hotasha'
];
let index = names.indexOf('Faquire');
names = [...names.slice(0, 3),'Riches', ...names.slice(index+1)];
console.log(names)
names.forEach(n=>console.log(n));