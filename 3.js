class Trainee {
    constructor(name, course, round){
        this.name=name;
        this.course=course;
        this.round=round;
    }
    toString() {
        return `${this.name}, ${this.course} ${this.round}`
    }
}
var t = new Trainee('Habib', 'ESAD', 61);
console.log(t.toString());
