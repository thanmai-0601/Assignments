import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class Student {
  private apiUrl = 'https://localhost:7188/api/Student';

  constructor(private http: HttpClient) { }

  addStudent(student: any) {
    return this.http.post(this.apiUrl, student);
  }

  getStudents() {
    return this.http.get(this.apiUrl);
  }
  
}
