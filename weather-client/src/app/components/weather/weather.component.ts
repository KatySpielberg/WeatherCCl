import { Component } from '@angular/core';
import { WeatherService } from 'src/app/services/weather.service';

@Component({
  selector: 'app-weather',
  templateUrl: './weather.component.html',
  styleUrls: ['./weather.component.scss']
})
export class WeatherComponent {
  countries = ['Israel', 'UK', 'USA'];
  citiesMap: { [key: string]: string[] } = {
    Israel: ['Tel Aviv', 'Jerusalem', 'Haifa'],
    UK: ['London', 'Manchester'],
    USA: ['New York', 'Los Angeles']
  };

  selectedCountry = '';
  selectedCity = '';
  days = 1;
  currentWeather = '';
  forecastData: any = null;

  constructor(private weatherService: WeatherService) {}

  onCountryChange() {
    this.selectedCity = '';
  }

  getWeather() {
    if (!this.selectedCity) return;

    this.weatherService.getCurrentWeather(this.selectedCity).subscribe(result => {
      this.currentWeather = result;
    });

    this.weatherService.getForecast(this.selectedCity, this.days).subscribe(result => {
      this.forecastData = result;
    });
  }
}