import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddEditReportComponent } from './add-edit-report/add-edit-report.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { HomepageComponent } from './homepage/homepage.component';
import { MsalGuard } from './msal.guard';

const routes: Routes = [
    {
        path: '',
        component: HomepageComponent,
    },
    {
        path: 'dashboard',
        component: DashboardComponent,
        canActivate: [MsalGuard],
    },
    {
        path: 'dashboard/add-report',
        component: AddEditReportComponent,
        canActivate: [MsalGuard],
        children: [{ path: ':id', component: AddEditReportComponent }],
    },
    {
        path: '**',
        component: HomepageComponent,
    },
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule],
})
export class AppRoutingModule {}
