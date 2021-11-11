import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Report } from '../models/report';
import { ReportsService } from '../services/reports.service';

@Component({
    selector: 'app-add-edit-report',
    templateUrl: './add-edit-report.component.html',
    styleUrls: ['./add-edit-report.component.scss'],
})
export class AddEditReportComponent implements OnInit, OnDestroy {
    report = new Report();
    reportForm!: FormGroup;
    private subscriptions = new Subscription();

    constructor(
        private fb: FormBuilder,
        private reportsService: ReportsService,
        private actRoute: ActivatedRoute,
        private router: Router
    ) {}

    ngOnInit(): void {
        this.subscriptions.add(
            // Bad: Nested subscriptions
            this.actRoute.firstChild?.params.subscribe((params: any) => {
                if (params.id !== undefined) {
                    this.subscriptions.add(
                        this.reportsService
                            .getReportById(params.id)
                            .subscribe((value) => {
                                this.report = value;
                                this.initForm();
                            })
                    );
                } else {
                    this.initForm();
                }
            })
        );
        this.initForm();
    }

    initForm() {
        this.reportForm = this.fb.group({
            reporterId: this.fb.control(this.report.reporterId),
            flightId: this.fb.control(this.report.flightId),
            description: this.fb.control(this.report.description),
        });
    }

    saveReport() {
        const formValues = this.reportForm.value;

        this.report.reporterId = formValues.reporterId as number;
        this.report.flightId = formValues.flightId as number;
        this.report.description = formValues.description;

        if (this.report.id !== 0) {
            this.subscriptions.add(
                this.reportsService
                    .updateReport(this.report)
                    .subscribe(() => this.router.navigate(['dashboard']))
            );
        } else {
            this.subscriptions.add(
                this.reportsService
                    .addReport(this.report)
                    .subscribe(() => this.router.navigate(['dashboard']))
            );
        }
    }

    ngOnDestroy(): void {
        if (this.subscriptions) this.subscriptions.unsubscribe();
    }
}
