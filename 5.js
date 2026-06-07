var str = "The standards for JavaScript are the ECMAScript Language Specification (ECMA-262) and the ECMAScript Internationalization API specification (ECMA-402). As soon as one browser implements a feature, we try to document it. This means that cases where some proposals for new ECMAScript features have already been implemented in browsers, documentation and examples in MDN articles may use some of those new features. Most of the time, this happens between the stages 3 and 4, and is usually before the spec is officially published.";
var index = str.indexOf('ECMAScript');
if(index>=0){
    console.log("String contains \"ECMAScript\" at postion "+index);
}
if(str.includes('ECMAScript')){
    console.log("String contains \"ECMAScript\"");
}
var storyText = `I know not where I was born, save that the castle was infinitely old and infinitely horrible.`;
var replacedText = storyText.replaceAll('infinitely', 'umrittu');
console.log(replacedText);