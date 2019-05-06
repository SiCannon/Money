import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BankAccountListComponent } from './bank-account-list/bank-account-list.component';

@NgModule({
    imports: [
        CommonModule
    ],
    declarations: [BankAccountListComponent],
    exports: [BankAccountListComponent]
})
export class BankAccountModule { }
