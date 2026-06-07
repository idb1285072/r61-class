let emailPattern = /^\S+@\S+\.\S+$/
console.log(emailPattern.test('domain.habib'))
console.log(emailPattern.test('domain.habib123@gamil.com'))
console.log(emailPattern.test('domain_habib@yahoo.com'))
console.log(emailPattern.test('domain_habib@yahoo.co.uk'))