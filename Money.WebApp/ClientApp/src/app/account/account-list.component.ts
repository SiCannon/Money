import { Component, Inject, OnInit } from '@angular/core';
import { BankAccount } from './bank-account';
import { AccountService } from './account.service';

@Component({
    selector: 'app-account-list',
    templateUrl: './account-list.component.html',
    styleUrls: ['./account-list.component.less']
})
export class AccountListComponent implements OnInit {

    public accounts: BankAccount[];

    constructor(private accountService: AccountService) {
    }

    ngOnInit() {
        this.accountService.getAll().subscribe(x => {
            this.accounts = x;
        });
    }
}
