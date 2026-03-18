
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Job } from '../models/job';

@Injectable({
  providedIn: 'root'
})
export class JobService {

  constructor(private http:HttpClient) { }

  getJob()
  {
    return this.http.get<Job[]>(environment.baseurl+'/job')
  }
  addJob(job:Job[]){
    
    return this.http.post(environment.baseurl+'/job',job)

  }
}
