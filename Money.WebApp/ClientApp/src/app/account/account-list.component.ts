import { Component, Inject, OnInit } from '@angular/core';

@Component({
    selector: 'app-account-list',
    templateUrl: './account-list.component.html'
})
export class AccountListComponent implements OnInit {

    //public forecasts: WeatherForecast[];

    //constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    //  http.get<WeatherForecast[]>(baseUrl + 'api/SampleData/WeatherForecasts').subscribe(result => {
    //    this.forecasts = result;
    //  }, error => console.error(error));
    //}

    ngOnInit() {
        //this.logIt(`OnInit`);
    }
}
