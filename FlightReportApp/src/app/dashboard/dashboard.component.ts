import { Component, OnInit } from '@angular/core';
import { MsalService } from '@azure/msal-angular';
import { Observable, of, Subscription } from 'rxjs';
import { Plane } from '../Models/plane';
import { PlanesService } from '../planes.service';

@Component({
    selector: 'app-dashboard',
    templateUrl: './dashboard.component.html',
    styleUrls: ['./dashboard.component.scss'],
})
export class DashboardComponent implements OnInit {
    public planes$: Observable<Plane[]> = this.planeService.getPlanes();

    constructor(
        private msalService: MsalService,
        private planeService: PlanesService
    ) {}

    ngOnInit(): void {}

    getUsername(): string {
        return this.msalService.instance.getActiveAccount()?.name!;
    }
}
