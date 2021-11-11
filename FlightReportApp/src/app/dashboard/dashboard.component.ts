import { Component, OnDestroy, OnInit } from '@angular/core';
import { MsalService } from '@azure/msal-angular';
import { Observable, of, Subscription } from 'rxjs';
import { Airport } from '../models/airport';
import { Plane } from '../models/plane';
import { Report } from '../models/report';
import { ReportsService } from '../services/reports.service';

@Component({
    selector: 'app-dashboard',
    templateUrl: './dashboard.component.html',
    styleUrls: ['./dashboard.component.scss'],
})
export class DashboardComponent implements OnInit, OnDestroy {
    public reports$!: Observable<Report[]>;
    private subscriptions = new Subscription();

    /* example
    public planes: Plane[] = [];*/

    constructor(
        private msalService: MsalService,
        private reportService: ReportsService
    ) {}

    ngOnInit(): void {
        this.reports$ = this.reportService.getReports();
    }

    getUsername(): string {
        return this.msalService.instance.getActiveAccount()?.name!;
    }

    deleteReport(id: number) {
        if (confirm('Are you sure you want to delete this report ?')) {
            this.subscriptions.add(
                this.reportService.deleteReport(id).subscribe((value) => {
                    this.reports$ = this.reportService.getReports();
                })
            );
        }
    }

    ngOnDestroy(): void {
        this.subscriptions.unsubscribe();
    }
}
