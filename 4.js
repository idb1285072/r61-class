const crypto = require('crypto').webcrypto;
console.log(Math.random())
for(let i=1; i<=10;i++){
    console.log(Math.floor(Math.random()*(50-25+1)+25));
}
console.log();
const randomBuffer = new Uint32Array(1);
crypto.getRandomValues(randomBuffer);
const randomFraction = randomBuffer[0] / (0xffffffff + 1);
console.log(Math.floor(randomFraction*(50-25)+25)+1);