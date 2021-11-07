import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Plane } from './Models/plane';

@Injectable({
    providedIn: 'root',
})
export class PlanesService {
    constructor(private http: HttpClient) {}
    private apiUrl: string = 'https://localhost:44385/api/WeatherForecast';

    public getPlanes(): Observable<Plane[]> {
        return this.http.get<Plane[]>(this.apiUrl);
    }
}
