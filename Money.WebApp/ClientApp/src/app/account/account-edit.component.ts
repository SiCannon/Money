import { Component, Inject, OnInit } from '@angular/core';
import { BankAccount } from './bank-account';
import { AccountService } from './account.service';

@Component({
    selector: 'app-account-edit',
    templateUrl: './account-edit.component.html',
    styleUrls: ['./account-edit.component.less']
})
export class AccountEditComponent implements OnInit {

    constructor(private accountService: AccountService) {
    }

    ngOnInit() {
        //this.accountService.getById().subscribe(x => {
        //    //this.accounts = x;
        //});
    }
}
