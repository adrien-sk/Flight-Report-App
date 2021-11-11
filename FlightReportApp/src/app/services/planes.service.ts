import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';

@Injectable({
    providedIn: 'root',
})
export class PlanesService {
    private apiUrl: string = environment.apiUrl + '/Plane';

    constructor(private http: HttpClient) {}
}
