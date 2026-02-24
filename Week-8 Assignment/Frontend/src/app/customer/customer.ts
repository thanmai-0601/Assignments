import { Component, inject, signal } from '@angular/core';
import { DecimalPipe } from '@angular/common';
import { Sidebar } from '../layout/sidebar';
import { PolicyService, Policy } from '../services/policy.service';

@Component({
  standalone: true,
  templateUrl: './customer.html',
  styleUrl: './customer.css',
  imports: [Sidebar, DecimalPipe]
})
export class Customer {

  private service = inject(PolicyService);
  policies = signal<Policy[]>([]);

  ngOnInit() {
    this.service.getAll().subscribe(d => this.policies.set(d));
  }
}