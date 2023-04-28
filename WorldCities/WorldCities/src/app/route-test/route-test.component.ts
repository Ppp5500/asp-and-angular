import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { environment } from '../../environments/environment';

@Component({
  selector: 'app-route-test',
  templateUrl: './route-test.component.html',
  styleUrls: ['./route-test.component.scss']
})
export class RouteTestComponent implements OnInit {
  public forecasts?: WeatherForecast[];

  public testText: string = 'connected!';

  constructor(http: HttpClient) {
    console.log('test');
    http.get<WeatherForecast[]>(environment.baseUrl + 'api/weatherforecast')
      .subscribe(result => {
        this.forecasts = result;
        console.log('log');
      }, error => console.error(error));
  }

  ngOnInit(): void {
  }

}

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
