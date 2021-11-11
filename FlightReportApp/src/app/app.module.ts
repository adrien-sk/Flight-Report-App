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

export function MSALInstanceFactory(): IPublicClientApplication {
    return new PublicClientApplication({
        auth: {
            clientId: '369971f2-92d1-454b-9684-edd0e2fa4749',
            authority:
                'https://login.microsoftonline.com/fd755ac7-b319-4998-84e0-a4605afd4ef0',
            redirectUri: 'http://localhost:4200/',
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
