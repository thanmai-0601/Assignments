import { Component, inject, signal } from '@angular/core';
import { DecimalPipe } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Sidebar } from '../layout/sidebar';
import { PolicyService, Policy } from '../services/policy.service';

@Component({
  standalone: true,
  templateUrl: './agent.html',
  styleUrl: './agent.css',
  imports: [FormsModule, Sidebar, DecimalPipe]
})
export class Agent {

  private service = inject(PolicyService);
  policies = signal<Policy[]>([]);

  active = 'list';
  editingPolicy: Policy | null = null;

  editForm: Policy = {
    policyName: '',
    provider: '',
    premium: 0,
    coverageAmount: 0
  };

  ngOnInit() {
    this.load();
  }

  load() {
    this.service.getAll().subscribe(d => this.policies.set(d));
  }

  startEdit(p: Policy) {
    this.editingPolicy = p;
    // clone the policy into the form so edits don't mutate the list directly
    this.editForm = { ...p };
  }

  save() {
    if (!this.editingPolicy?.id) return;
    this.service.update(this.editingPolicy.id, this.editForm).subscribe(() => {
      this.editingPolicy = null;
      this.load();
    });
  }
}