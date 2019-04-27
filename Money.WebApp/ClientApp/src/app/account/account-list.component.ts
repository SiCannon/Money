import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BankAccount } from './bank-account';
import { AccountService } from './account.service';

@Component({
    selector: 'app-account-list',
    templateUrl: './account-list.component.html'
})
export class AccountListComponent implements OnInit {

    public accounts: BankAccount[];

    //constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    //    http.get<BankAccount[]>(baseUrl + 'api/account/GetAll').subscribe(result => {
    //        this.accounts = result;
    //    }, error => console.error(error));
    //}

    constructor(private accountService: AccountService) {
    }

    ngOnInit() {
        this.accountService.getAll().subscribe(x => {
            this.accounts = x;
        });
    }
}
