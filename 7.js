function getMeANumberV1(cb){
    setTimeout(()=>{
        let n = Math.floor(Math.random()*(100-50)+50)+1;
        cb(n);
    }, 2000)
}
getMeANumberV1(n=>{
    console.log(n);
});
function getMeANumberV2(n){
    let promise = new Promise((resolve, reject)=>{
        setTimeout(()=>{
            let n = Math.floor(Math.random()*(100-50)+50)+1;
            //console.log(n)
            if(n <70) resolve(n);
            else reject('Insuffucient fund')
        
        }, 2000)
    })

    return promise;
}

getMeANumberV2().then(n=>{
    console.log(n)
}).catch(e=>{
    console.log(e)
});

function getMeANumberV3(){
    setTimeout(()=>{
        let n = Math.floor(Math.random()*(100-50)+50)+1;
       return n;
    }, 2000)
}
 async function call(){
    let n = await getMeANumberV3();
    console.log(n);
}
call();