let str = 'water is life. But water brigs havoc to humanity. Floads, tsunami are the most davasting'+
' havoc caused by water';
let pattern = /[Ww]\w*r/g
let matches =str.matchAll(pattern);
for(let m of matches){
    console.log(`Match index: ${m.index} found match: ${m[0]}`);
}
console.log(str[0].toUpperCase()+str.slice(1))