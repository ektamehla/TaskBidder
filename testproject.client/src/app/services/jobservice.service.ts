import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Job } from '../models/job';

@Injectable({
  providedIn: 'root'
})
export class JobserviceService {

  private apiUrl = 'http://localhost:5134/api/jobs'; 

  constructor(private http: HttpClient) { }

  // Fetch all jobs
  getAllJobs(): Observable<Job[]> {
    return this.http.get<Job[]>(`${this.apiUrl}/all`);
  }

  // Fetch recent jobs
  getRecentJobs(): Observable<Job[]> {
    return this.http.get<Job[]>(`${this.apiUrl}/recent`);
  }

  // Fetch active jobs
  getActiveJobs(): Observable<Job[]> {
    return this.http.get<Job[]>(`${this.apiUrl}/active`);
  }

  // Place a new bid
  createBid(jobId: number, bidAmount: number): Observable<any> {
    const bid = { jobId, amount: bidAmount };
    return this.http.post(`${this.apiUrl}/${jobId}/bids`, bid);
  }

  createJob(job: Partial<Job>): Observable<Job> {
    return this.http.post<Job>(`${this.apiUrl}`, job);
  }

}
