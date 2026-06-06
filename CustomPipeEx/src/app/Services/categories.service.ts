import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { Category } from '../Models/category.model';

@Injectable({
  providedIn: 'root'
})
export class CategoriesService {

  apiUrl=environment.apiUrl
  constructor(private client:HttpClient) { }
  Get(){
    const  t = localStorage.getItem("access_token")??"";
    const headers_object = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': "Bearer " + t
    });

    const httpOptions = {
      headers: headers_object
    };
   return this.client.get<Category[]>(this.apiUrl+"Categories",httpOptions);
  }
  GetbyId(id:number){
    return this.client.get<Category>(this.apiUrl+"Categories/"+id);
   }
  Save(category:Category){
    //debugger;
  return  this.client.post(this.apiUrl+"Categories",category);
  }
  Update(category:Category){
    //debugger;
   return this.client.put(this.apiUrl+"Categories/"+category.id,category);
  }
  Delete(id:number){
    return this.client.delete(this.apiUrl+"Categories/"+id);
  }
}
