import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Policy {
  id?: number;
  policyName: string;
  provider: string;
  premium: number;
  coverageAmount: number;
}

@Injectable({
  providedIn: 'root'
})
export class PolicyService {

  private api = 'https://localhost:7143/api/Policies'; // change if needed

  constructor(private http: HttpClient) {}

  // GET ALL
  getAll(): Observable<Policy[]> {
    return this.http.get<Policy[]>(this.api);
  }

  // ADD
  add(policy: Policy): Observable<any> {
    return this.http.post(this.api, policy);
  }

  // DELETE
  delete(id: number): Observable<any> {
    return this.http.delete(`${this.api}/${id}`);
  }

  // UPDATE (future use)
  update(id: number, policy: Policy): Observable<any> {
    return this.http.put(`${this.api}/${id}`, policy);
  }
}