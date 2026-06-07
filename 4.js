function Trainee(name, course, round){
    this.name=name;
    this.course=course;
    this.round = round;
    
}
let t1 = new Trainee('Habib', 'ESAD', 61);
Trainee.prototype.toString =  function(){
    return `${this.name}, ${this.course} ${this.round}`;
}
let t2 = new Trainee('Habib1', 'ESAD', 61);
console.log(t1.toString())
console.log(t2.toString());
console.log(typeof t1)