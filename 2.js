//check a variable exist & non-empty string
var nonEmptyStringVar = '';
if(typeof nonEmptyStringVar != 'undefined' && nonEmptyStringVar.trim().length){
    console.log(nonEmptyStringVar)
}
else {
    console.log('var is empty string')
}