import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Report } from '../models/report';

@Injectable({
    providedIn: 'root',
})
export class ReportsService {
    private apiUrl: string = 'https://localhost:44385/api/v1/Report';
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
}
