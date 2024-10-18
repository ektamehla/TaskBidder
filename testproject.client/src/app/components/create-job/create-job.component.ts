// src/app/components/create-job/create-job.component.ts

import { Component } from '@angular/core';
import { JobserviceService } from '../../services/jobservice.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-job',
  templateUrl: './create-job.component.html',
  styleUrls: ['./create-job.component.css']
})
export class CreateJobComponent {
  description: string = '';
  requirements: string = '';
  posterName: string = '';
  contactInfo: string = '';

  constructor(private jobService: JobserviceService, private router: Router) { }

  createJob() {
    const newJob = {
      description: this.description,
      requirements: this.requirements,
      posterName: this.posterName,
      contactInfo: this.contactInfo,
      createdAt: new Date().toISOString(),
      expirationDate: new Date(new Date().setDate(new Date().getDate() + 7)).toISOString() // Job expires in 7 days
    };

    this.jobService.createJob(newJob).subscribe(() => {
      this.router.navigate(['/']);
    });
  }
}
