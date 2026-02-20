import { CommonModule } from '@angular/common';
import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Student } from '../../Services/student';

@Component({
  selector: 'app-student-form',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './student-form.html'
})
export class StudentForm implements OnInit {

  student: any = {
    id: 0,
    name: '',
    email: '',
    age: 0,
    course: ''
  };

  students: any[] = [];
  isEditMode = false;

  constructor(
    private studentService: Student,
    private cdr: ChangeDetectorRef   // 🔥 force UI refresh
  ) {}

  ngOnInit(): void {
    this.loadStudents();
  }

  loadStudents() {
    this.studentService.getStudents().subscribe({
      next: (data) => {
        this.students = [...data];   // 🔥 new reference forces refresh
        this.cdr.detectChanges();    // 🔥 ensures UI updates immediately
      },
      error: (err) => {
        console.error("Error loading students:", err);
      }
    });
  }

  submitForm() {

    if (this.isEditMode) {

      this.studentService.updateStudent(this.student.id, this.student)
        .subscribe({
          next: () => {
            this.resetForm();
            this.loadStudents();
          },
          error: (err) => {
            console.error("Update error:", err);
          }
        });

    } else {

      this.studentService.addStudent(this.student)
        .subscribe({
          next: () => {
            this.resetForm();
            this.loadStudents();
          },
          error: (err) => {
            console.error("Add error:", err);
          }
        });
    }
  }

  editStudent(s: any) {
    this.student = { ...s };
    this.isEditMode = true;
  }

  deleteStudent(id: number) {
    this.studentService.deleteStudent(id)
      .subscribe({
        next: () => {
          // 🔥 instantly remove from UI without waiting
          this.students = this.students.filter(s => s.id !== id);
          this.cdr.detectChanges();
        },
        error: (err) => {
          console.error("Delete error:", err);
        }
      });
  }

  resetForm() {
    this.student = {
      id: 0,
      name: '',
      email: '',
      age: 0,
      course: ''
    };
    this.isEditMode = false;
  }
}