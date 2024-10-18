// src/app/components/home-job/home-job.component.ts

import { Component, OnInit } from '@angular/core';
import { JobserviceService } from '../../services/jobservice.service';
import { Job } from '../../models/job';

@Component({
  selector: 'app-home-job',
  templateUrl: './home-job.component.html',
  styleUrls: ['./home-job.component.css']
})
export class HomeJobComponent implements OnInit {
  recentJobs: Job[] = [];
  activeJobs: Job[] = [];

  newBidAmount: number = 0;
  selectedJobId?: number;

  constructor(private jobService: JobserviceService) { }

  ngOnInit(): void {
    this.jobService.getRecentJobs().subscribe((jobs: Job[]) => {
      console.log("Recent Jobs: ", jobs)
      this.recentJobs = jobs;
    });

    this.jobService.getActiveJobs().subscribe((jobs: Job[]) => {
      console.log("Active Jobs: ", jobs)
      this.activeJobs = jobs;
    });
  }

  placeBid(jobId: number) {
    if (this.newBidAmount > 0) {
      console.log(`Placing a bid of ${this.newBidAmount} on job ${jobId}`);
      // Call the backend to place the bid
      // You may need to update the JobService to include a placeBid method
      this.newBidAmount = 0;
    }
  }
}
