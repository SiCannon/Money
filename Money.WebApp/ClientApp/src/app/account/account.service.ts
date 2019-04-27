import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { BankAccount } from './bank-account';

@Injectable({ providedIn: 'root' })
export class AccountService {
    constructor(
        private http: HttpClient) {
    }

    getAll(): Observable<BankAccount[]> {
        return this.http.get<BankAccount[]>('api/account/GetAll');
    }
}
