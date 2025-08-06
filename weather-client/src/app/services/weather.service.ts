import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class WeatherService {
  private apiUrl = 'https://localhost:7268/api/weather';

  constructor(private http: HttpClient) {}

  getCurrentWeather(city: string) {
    return this.http.get(`${this.apiUrl}/current?city=${city}`, { responseType: 'text' });
  }

  getForecast(city: string, days: number) {
    return this.http.get(`${this.apiUrl}/forecast?city=${city}&days=${days}`);
  }
}