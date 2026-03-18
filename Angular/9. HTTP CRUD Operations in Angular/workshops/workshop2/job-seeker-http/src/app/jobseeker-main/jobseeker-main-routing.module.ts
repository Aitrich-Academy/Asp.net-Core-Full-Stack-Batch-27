import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { JobseekerMainComponent } from './jobseeker-main.component';

const routes: Routes = [
  {
    path: 'jobseeker-home',
    component: JobseekerMainComponent,
    children: [
      { path: '',loadChildren:()=>import('../jobs/jobs.module').then(m=>m.JobsModule)},
      { path: 'sidebar', loadChildren: () => import('../shared/shared.module').then(m => m.SharedModule) }
      
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class JobseekerMainRoutingModule { }
