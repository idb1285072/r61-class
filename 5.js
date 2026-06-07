class Person {
    constructor(
        name,
        address
    ){
        this.name=name;
        this.address = address;
    }
    details(){
        return `${this.name}, ${this.address}`;
    }
}
class Employee extends Person{
    constructor(id, post, dept, name, address){
        super(name, address);
        this.id=id;
        this.dept=dept;
        this.post = post;
    }
    details(){
        return `ID: ${this.id} ${super.details()}\n${this.post}, ${this.dept}`
    }
}
let emp1 = new Employee(1, 'Manager','IT', 'Habib', 'Janina');
console.log(emp1.details())
let p1 = new Person('You', 'Somewhere');
console.log(p1.details());
export {Person,Employee}