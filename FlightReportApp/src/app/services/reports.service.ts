import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Report } from '../models/report';
import { environment } from '../../environments/environment';

@Injectable({
    providedIn: 'root',
})
export class ReportsService {
    private apiUrl: string = environment.apiUrl + '/Report';
    constructor(private http: HttpClient) {}

    public getReports(): Observable<Report[]> {
        return this.http.get<Report[]>(this.apiUrl);
    }

    public getReportById(id: number): Observable<Report> {
        return this.http.get<Report>(this.apiUrl + '/' + id);
    }

    public addReport(report: Report): Observable<Report> {
        return this.http.post<Report>(this.apiUrl, report);
    }

    public updateReport(report: Report): Observable<Report> {
        return this.http.put<Report>(this.apiUrl + '/' + report.id, report);
    }

    public deleteReport(id: number): Observable<any> {
        return this.http.delete(this.apiUrl + '/' + id);
    }
}
