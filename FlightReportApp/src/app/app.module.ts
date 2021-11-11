import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { MsalModule, MsalService, MSAL_INSTANCE } from '@azure/msal-angular';
import {
    IPublicClientApplication,
    PublicClientApplication,
} from '@azure/msal-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { HomepageComponent } from './homepage/homepage.component';
import { AddEditReportComponent } from './add-edit-report/add-edit-report.component';
import { ReactiveFormsModule } from '@angular/forms';
import { environment } from '../environments/environment';

export function MSALInstanceFactory(): IPublicClientApplication {
    return new PublicClientApplication({
        auth: {
            clientId: environment.auth.clientId,
            authority: environment.auth.authority,
            redirectUri: environment.auth.redirectUri,
        },
    });
}

@NgModule({
    declarations: [
        AppComponent,
        DashboardComponent,
        HomepageComponent,
        AddEditReportComponent,
    ],
    imports: [
        BrowserModule,
        AppRoutingModule,
        MsalModule,
        HttpClientModule,
        ReactiveFormsModule,
    ],
    providers: [
        {
            provide: MSAL_INSTANCE,
            useFactory: MSALInstanceFactory,
        },
        MsalService,
    ],
    bootstrap: [AppComponent],
})
export class AppModule {}
