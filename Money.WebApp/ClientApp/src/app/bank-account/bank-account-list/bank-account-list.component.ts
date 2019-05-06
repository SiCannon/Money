import { Component, Inject, OnInit } from '@angular/core';
import { BankAccount } from '../bank-account';
import { BankAccountService } from '../bank-account.service';

@Component({
  selector: 'app-bank-account-list',
  templateUrl: './bank-account-list.component.html',
  styleUrls: ['./bank-account-list.component.css']
})
export class BankAccountListComponent implements OnInit {

    public bankAccounts: BankAccount[];

    constructor(
        private bankAccountService: BankAccountService) {
        console.log(bankAccountService);
    }

    ngOnInit() {
        this.bankAccountService.getAll().subscribe(x => {
            this.bankAccounts = x;
        });
    }

}
