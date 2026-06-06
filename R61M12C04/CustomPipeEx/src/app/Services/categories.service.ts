import { HttpClient } from '@angular/common/http';
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
   return this.client.get<Category[]>(this.apiUrl+"Categories");
  }
  Save(category:Category){
  return  this.client.post(this.apiUrl+"Categories",category);
  }
  Update(category:Category){
    this.client.put(this.apiUrl+"Categories/"+category.id,category);
  }
  Delete(id:number){
    this.client.delete(this.apiUrl+"Categories/"+id);
  }
}
