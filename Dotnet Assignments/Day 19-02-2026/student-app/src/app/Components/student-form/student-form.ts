import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Student } from '../../Services/student';

@Component({
  selector: 'app-student-form',
  standalone: true,
  imports: [FormsModule,CommonModule],
  templateUrl: './student-form.html'
})
export class StudentForm implements OnInit {
  student = {
    name: '',
    email: '',
    age: 0,
    course: ''
  };

  students: any;

  constructor(private studentService: Student) {}

  ngOnInit() {
    this.loadStudents();
  }

  submitForm() {
    this.studentService.addStudent(this.student).subscribe(() => {
      alert("Student Added Successfully!");
      this.loadStudents();
    });
  }

  loadStudents() {
    this.studentService.getStudents().subscribe((data: any) => {
      this.students = data;
    });
  }

}
