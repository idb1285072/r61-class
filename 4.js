var s1='ESAD';
var s2='Esad';
if(s1.toLowerCase() == s2.toLowerCase()){
    console.log('Same string value');
}
if(s1.localeCompare(s2, 'en', {sensitivity:'accent'})===0){
    console.log('Same string value');
}