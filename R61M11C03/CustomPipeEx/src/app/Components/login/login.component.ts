import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { User } from '../../Models/user.model';
import { AuthService } from '../../Services/auth.service';
import { AccessToken } from '../../Models/access-token.model';

@Component({
  selector: 'app-login',
  imports: [CommonModule,FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
 isClicked:boolean=false;
 token: AccessToken = new AccessToken;
user:User={
  email: '',
  password: ''
}
constructor(private authsrv:AuthService){}
onSubmit(){
  this.isClicked=true;
this.authsrv.Login(this.user)
.subscribe({
  next:(response)=>{
    this.token=response;
    console.log(this.token.token)
    this.authsrv.setToken(this.token.token)
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
