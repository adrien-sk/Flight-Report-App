import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root',
})
export class PlanesService {
    constructor(private http: HttpClient) {}
    private apiUrl: string = 'https://localhost:44385/api/v1/Airport';

    /*public getPlanes(): Observable<Airport[]> {
        return this.http.get<Airport[]>(this.apiUrl);
    }

    public update() {
        console.log('update !!!!');
        let airport = new Airport();
        airport.code = 'COL';
        airport.country = 'FranceTest';
        airport.name = 'Colmar';
        let testt = this.http.post<Airport>(this.apiUrl, airport);
        testt.subscribe((value) => console.log(value));
    }*/
}
