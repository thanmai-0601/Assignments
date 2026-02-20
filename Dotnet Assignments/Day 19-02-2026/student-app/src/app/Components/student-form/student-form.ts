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
  showList: boolean = false;

  constructor(
    private studentService: Student,
    private cdr: ChangeDetectorRef
  ) {}

  ngOnInit(): void {
    this.loadStudents();
  }

  toggleList() {
    this.showList = !this.showList;
  }

  loadStudents() {
    this.studentService.getStudents().subscribe({
      next: (data) => {
        this.students = [...data];
        this.cdr.detectChanges();
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

            alert("✅ Student updated successfully!");

            this.resetForm();
            this.loadStudents();
          },
          error: (err) => {
            console.error("Update error:", err);
            alert("❌ Failed to update student.");
          }
        });

    } else {

      this.studentService.addStudent(this.student)
        .subscribe({
          next: () => {

            alert("🎉 Student added successfully!");

            this.resetForm();
            this.loadStudents();
          },
          error: (err) => {
            console.error("Add error:", err);
            alert("❌ Failed to add student.");
          }
        });
    }
  }

  editStudent(s: any) {
    this.student = { ...s };
    this.isEditMode = true;
  }

  deleteStudent(id: number) {

    const confirmDelete = confirm("Are you sure you want to delete this student?");

    if (!confirmDelete) return;

    this.studentService.deleteStudent(id)
      .subscribe({
        next: () => {

          this.students = this.students.filter(s => s.id !== id);
          this.cdr.detectChanges();

          alert("🗑️ Student deleted successfully!");
        },
        error: (err) => {
          alert("❌ Failed to delete student.");
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