import { Component, inject, signal } from '@angular/core';
import { DecimalPipe } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Sidebar } from '../layout/sidebar';
import { PolicyService, Policy } from '../services/policy.service';
import { UserService, AppUser } from '../services/user.service';

@Component({
  standalone: true,
  templateUrl: './admin.html',
  styleUrl: './admin.css',
  imports: [FormsModule, Sidebar, DecimalPipe]
})
export class Admin {

  private policyService = inject(PolicyService);
  private userService = inject(UserService);
  private route = inject(ActivatedRoute);

  active = 'list';
  policies = signal<Policy[]>([]);
  users = signal<AppUser[]>([]);

  // Add form
  form: Policy = { policyName: '', provider: '', premium: 0, coverageAmount: 0 };

  // Edit state
  editingPolicy: Policy | null = null;
  editForm: Policy = { policyName: '', provider: '', premium: 0, coverageAmount: 0 };

  ngOnInit() {
    this.route.queryParams.subscribe(params => {
      if (params['tab']) this.active = params['tab'];
    });
    this.loadPolicies();
    this.loadUsers();
  }

  loadPolicies() {
    this.policyService.getAll().subscribe(d => this.policies.set(d));
  }

  loadUsers() {
    this.userService.getAll().subscribe(d => this.users.set(d));
  }

  // Add
  add() {
    this.policyService.add(this.form).subscribe(() => {
      this.loadPolicies();
      this.active = 'list';
      this.form = { policyName: '', provider: '', premium: 0, coverageAmount: 0 };
    });
  }

  // Delete
  delete(id: number) {
    this.policyService.delete(id).subscribe(() => this.loadPolicies());
  }

  // Edit
  startEdit(p: Policy) {
    this.editingPolicy = p;
    this.editForm = { ...p };
  }

  save() {
    if (!this.editingPolicy?.id) return;
    this.policyService.update(this.editingPolicy.id, this.editForm).subscribe(() => {
      this.editingPolicy = null;
      this.loadPolicies();
    });
  }
}