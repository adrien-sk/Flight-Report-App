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
export class DashboardComponent implements OnInit {
    public reports$!: Observable<Report[]>;

    /* example
    public planes: Plane[] = [];
    public subscriptions = new Subscription();*/

    constructor(
        private msalService: MsalService,
        private reportService: ReportsService
    ) {}

    ngOnInit(): void {
        this.reports$ = this.reportService.getReports();

        /* example
        this.subscriptions.add(
            this.planeService.getPlanes().subscribe((value) => {
                this.planes = value;
            })
        );*/
    }

    getUsername(): string {
        return this.msalService.instance.getActiveAccount()?.name!;
    }

    /* example
    ngOnDestroy(): void {
        this.subscriptions.unsubscribe();
    }*/
}
