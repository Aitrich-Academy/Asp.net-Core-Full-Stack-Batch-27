import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { forkJoin, mergeMap } from 'rxjs';
import { environment } from 'src/environments/environments';

@Injectable({
  providedIn: 'root'
})
export class JobService {

  constructor(private http:HttpClient) { }

  getJobs(){
    return this.http.get<any[]>(environment.baseurl +'/jobs')
  }

  getAppliedJobs() {
    return this.http.get<any[]>(environment.baseurl +'/applications')
  }

  getJobsById(id: string) {
    return this.http.get<any[]>(environment.baseurl +'/jobs/'+id)
  }

}
