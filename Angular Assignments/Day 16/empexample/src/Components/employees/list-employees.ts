import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Employee } from '../../models/employee/employee.model';

@Component({
  selector: 'app-list-employees',
  imports: [DatePipe],
  templateUrl: './list-employees.html',
  styleUrl: './list-employees.css',
})
export class ListEmployeesComponent implements OnInit { 
  employees: Employee[] = [ 
    { 
      id: 1, 
      name: 'Mark', 
      gender: 'Male', 
      contactPreference: 'Email', 
      email: 'mark@pragimtech.com',
      phoneNumber: 6281332238, 
      dateOfBirth: new Date('10/25/1988'), 
      department: 'IT', 
      isActive: true, 
      photoPath: 'john.jpeg' 
    }, 
    { 
      id: 2, 
      name: 'Mary', 
      gender: 'Female', 
      contactPreference: 'Phone',
      email: 'mary@google.com', 
      phoneNumber: 2345978640, 
      dateOfBirth: new Date('11/20/1979'), 
      department: 'HR', 
      isActive: true, 
      photoPath: 'mary.jpeg' 
    }, 
    { 
      id: 3, 
      name: 'John', 
      gender: 'Male', 
      contactPreference: 'Phone', 
      email:'john@yahoo.com',
      phoneNumber: 5432978640,
       dateOfBirth: new Date('3/25/1976'), 
      department: 'IT', 
      isActive: false, 
      photoPath: 'mark.jpeg' 
    }, 
  ]; 
  constructor() { } 
 
  ngOnInit() { 
  } 
} 