import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class UserData {
  private http=inject(HttpClient)
  getUsers(){
    return this.http.get<any>("http://localhost:3000/users")
  }
  getUserById(id:number){
    return this.http.get<any>(`http://localhost:3000/users/${id}`)
  }
  postUsers(user:any){
    return this.http.post<any>("http://localhost:3000/users",user)
  }
  UpdateUsers(user:any,id:number){
    return this.http.put<any>(`http://localhost:3000/users/${id}`,user)
  }
  deleteUser(id:number){
    return this.http.delete(`http://localhost:3000/users/${id}`)
  }

}
