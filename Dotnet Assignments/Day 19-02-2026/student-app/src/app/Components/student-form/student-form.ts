import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Student } from '../../Services/student';

@Component({
  selector: 'app-student-form',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './student-form.html'
})
export class StudentForm implements OnInit {

  // Object for form binding
  student: any = {
    id: 0,
    name: '',
    email: '',
    age: 0,
    course: ''
  };

  students: any[] = [];   // Holds student list
  isEditMode = false;     // Tracks edit mode
  showList: boolean = false; // Controls list visibility

  constructor(private studentService: Student) {}

  ngOnInit(): void {
    this.loadStudents();  // Load data on component start
  }

  toggleList() {
    this.showList = !this.showList;
  }

  // Fetch students from API
  loadStudents() {
    this.studentService.getStudents().subscribe({
      next: (data) => {
        this.students = [...data];
      },
      error: () => {
        alert("❌ Failed to load students.");
      }
    });
  }

  submitForm() {

    if (this.isEditMode) {

      // Update existing student
      this.studentService.updateStudent(this.student.id, this.student)
        .subscribe({
          next: () => {
            alert("✅ Student updated successfully!");
            this.resetForm();
            this.loadStudents();
          },
          error: () => {
            alert("❌ Failed to update student.");
          }
        });

    } else {

      // Add new student
      this.studentService.addStudent(this.student)
        .subscribe({
          next: () => {
            alert("🎉 Student added successfully!");
            this.resetForm();
            this.loadStudents();
          },
          error: () => {
            alert("❌ Failed to add student.");
          }
        });
    }
  }

  // Populate form for editing
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
          alert("🗑️ Student deleted successfully!");
        },
        error: () => {
          alert("❌ Failed to delete student.");
        }
      });
  }

  // Reset form to default state
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