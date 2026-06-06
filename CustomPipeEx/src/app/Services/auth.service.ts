import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { User } from '../Models/user.model';
import { Router } from '@angular/router';
import { AccessToken } from '../Models/access-token.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
apiUrl=environment.apiUrl
private token: string | null = null;
  constructor(private client:HttpClient,private router:Router) { }
  // Get(){
  //  return this.client.get<Category[]>(this.apiUrl+"Categories");
  // }
  // GetbyId(id:number){
  //   return this.client.get<Category>(this.apiUrl+"Categories/"+id);
  //  }
  Register(user:User){
    //debugger;
  return  this.client.post(this.apiUrl+"Accounts",user);
  }
  Login(user:User){
    //debugger;
  return  this.client.post<AccessToken>(this.apiUrl+"Accounts/Login",user);
  }
  // Update(category:Category){
  //   //debugger;
  //  return this.client.put(this.apiUrl+"Categories/"+category.id,category);
  // }
  Delete(id:number){
    return this.client.delete(this.apiUrl+"Accounts/"+id);
  }
  setToken(token: string): void {
    this.token = token;
    localStorage.setItem('access_token', token);
  }
  getToken(): string | null {
    return this.token || localStorage.getItem('access_token');
  }
  logout(): void {
    this.token = null;
    localStorage.removeItem('access_token');
    this.router.navigate(['/login']);
  }
  isAuthenticated(): boolean {
    return this.getToken() !== null;
  }

}
