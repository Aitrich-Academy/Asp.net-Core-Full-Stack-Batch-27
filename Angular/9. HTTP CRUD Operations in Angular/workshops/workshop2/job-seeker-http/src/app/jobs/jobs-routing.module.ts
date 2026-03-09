import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { JobsComponent } from './jobs.component';
import { AlljobsListComponent } from './components/alljobs-list/alljobs-list.component';
import { SharedModule } from '../shared/shared.module';
import { AlljobsNavbarComponent } from './components/alljobs-navbar/alljobs-navbar.component';
import { AppliedJobsComponent } from './components/applied-jobs/applied-jobs.component';

const routes: Routes = [

  {path:'findAllJobs',component:AlljobsListComponent},
  {path:'appliedJobs',component:AppliedJobsComponent}
 
];

@NgModule({
  imports: [RouterModule.forChild(routes),
  
  SharedModule],
  exports: [RouterModule]
})
export class JobsRoutingModule { }
