import { Component, OnInit } from '@angular/core';
import { UserData } from '../../Services/user-data';
import { Observable, BehaviorSubject, switchMap } from 'rxjs';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-users',
  templateUrl: './user.html',
  imports: [FormsModule, CommonModule]
})
export class UsersComponent implements OnInit {

  private refresh$ = new BehaviorSubject<void>(undefined);

  users$!: Observable<any[]>;
  singleUser$!: Observable<any>;

  user: any = this.getEmptyUser();
  isEdit = false;
  editUserId: number | null = null;

  constructor(private userService: UserData) {}

  ngOnInit(): void {
    this.users$ = this.refresh$.pipe(
      switchMap(() => this.userService.getUsers())
    );
  }

  // ===== QUICK LOOK (Dynamic) =====
  showQuickUser(id: number) {
    this.singleUser$ = this.userService.getUserById(id);
  }

  // ===== ADD / UPDATE =====
  addUser() {
    if (this.isEdit && this.editUserId !== null) {
      this.userService.UpdateUsers(this.user, this.editUserId).subscribe(() => {
        this.afterSave();
      });
    } else {
      const tempUser = { ...this.user };

      this.afterSave(); // fast UI update

      this.userService.postUsers(tempUser).subscribe(() => {
        this.refresh$.next();
      });
    }
  }

  // ===== EDIT =====
  updateUser(user: any) {
    this.user = { ...user };
    this.editUserId = user.id;
    this.isEdit = true;
  }

  // ===== DELETE =====
  deleteUser(id: number) {
    if (!confirm('Are you sure you want to delete this user?')) return;

    // Refresh UI immediately
    this.refresh$.next();

    this.userService.deleteUser(id).subscribe(() => {
      // Clear quick look if deleted user was shown
      this.singleUser$ = undefined as any;
    });
  }

  // ===== RESET =====
  resetForm() {
    this.user = this.getEmptyUser();
    this.isEdit = false;
    this.editUserId = null;
  }

  private afterSave() {
    this.refresh$.next();
    this.resetForm();
  }

  private getEmptyUser() {
    return {
      name: '',
      email: '',
      age: null,
      phone: '',
      city: '',
      role: ''
    };
  }
}
