import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface AppUser {
    id: number;
    name: string;
    email: string;
    role: string;
}

@Injectable({
    providedIn: 'root'
})
export class UserService {

    private api = 'https://localhost:7143/api/Auth';

    constructor(private http: HttpClient) { }

    getAll(): Observable<AppUser[]> {
        return this.http.get<AppUser[]>(`${this.api}/users`);
    }
}
