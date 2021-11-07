import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MsalService } from '@azure/msal-angular';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
    title = 'FlightReportApp';

    constructor(private msalService: MsalService, private router: Router) {
        if (this.msalService.instance.getActiveAccount() !== null) {
            this.router.navigate(['/dashboard']);
        }
    }

    ngOnInit(): void {
        this.msalService.instance.handleRedirectPromise().then((res) => {
            if (res !== null && res.account !== null) {
                this.msalService.instance.setActiveAccount(res.account);
                this.router.navigate(['/dashboard']);
            }
        });
    }
}
