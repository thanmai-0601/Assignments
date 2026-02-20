import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class Student {

  private apiUrl = 'https://localhost:7188/api/Students'; //API URL

  constructor(private http: HttpClient) { }

  // GET ALL
  getStudents() {
    return this.http.get<any[]>(this.apiUrl);
  }

  // GET BY ID
  getStudentById(id: number) {
    return this.http.get<any>(`${this.apiUrl}/${id}`);
  }

  // POST
  addStudent(student: any) {
    return this.http.post(this.apiUrl, student);
  }

  // PUT
  updateStudent(id: number, student: any) {
    return this.http.put(`${this.apiUrl}/${id}`, student);
  }

  // DELETE
  deleteStudent(id: number) {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}