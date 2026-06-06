import { Component } from '@angular/core';
import { User } from '../../Models/user.model';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AuthService } from '../../Services/auth.service';

@Component({
  selector: 'app-register',
  imports: [CommonModule,FormsModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  isClicked:boolean=false;
user:User={
  email: '',
  password: ''
}
constructor(private authsrv:AuthService){}
onSubmit(){
  this.isClicked=true;
this.authsrv.Register(this.user)
.subscribe({
  next:(response)=>{
    console.log(response)
    this.clearAll();
  },
  error:(error)=>{
    console.log(error)
  }
})
}
clearAll(){
  this.isClicked=false;
  this.user =new User;
}
}
