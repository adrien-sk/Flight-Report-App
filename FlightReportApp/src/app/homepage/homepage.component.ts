import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MsalService } from '@azure/msal-angular';

@Component({
    selector: 'app-homepage',
    templateUrl: './homepage.component.html',
    styleUrls: ['./homepage.component.scss'],
})
export class HomepageComponent implements OnInit {
    constructor(private msalService: MsalService, private router: Router) {}

    ngOnInit(): void {}

    isLoggedIn(): boolean {
        return this.msalService.instance.getActiveAccount() !== null;
    }

    login() {
        this.msalService.loginRedirect();
    }
}
