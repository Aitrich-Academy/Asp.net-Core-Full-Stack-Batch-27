import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { JobprovidersComponent } from './jobproviders/jobproviders.component';

const routes: Routes = [
  { path: 'jobproviders', component: JobprovidersComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
