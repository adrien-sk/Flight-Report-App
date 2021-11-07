import { Component, OnDestroy, OnInit } from '@angular/core';
import { MsalService } from '@azure/msal-angular';
import { Observable, of, Subscription } from 'rxjs';
import { Plane } from '../Models/plane';
import { PlanesService } from '../planes.service';

@Component({
    selector: 'app-dashboard',
    templateUrl: './dashboard.component.html',
    styleUrls: ['./dashboard.component.scss'],
})
export class DashboardComponent implements OnInit, OnDestroy {
    public planes$: Observable<Plane[]> = this.planeService.getPlanes();

    /*public planes!: Plane[];
    public subscribers: Subscription[] = [];*/

    constructor(
        private msalService: MsalService,
        private planeService: PlanesService
    ) {}

    ngOnInit(): void {
        /*this.subscribers.push(
            this.planeService.getPlanes().subscribe((value) => {
                this.planes = value;
            })
        );*/
    }

    getUsername(): string {
        return this.msalService.instance.getActiveAccount()?.name!;
    }

    ngOnDestroy(): void {
        //this.subscribers.map((x) => x.unsubscribe());
    }
}
