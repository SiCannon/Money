import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
    selector: 'app-account-list',
    templateUrl: './account-list.component.html'
})
export class AccountListComponent implements OnInit {

    public accounts: Account[];

    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        http.get<Account[]>(baseUrl + 'api/Account/GetAll').subscribe(result => {
            this.accounts = result;
        }, error => console.error(error));
    }

    ngOnInit() {
        //this.logIt(`OnInit`);
    }
}

interface Account {
    Id: number;
    Name: string;
}
