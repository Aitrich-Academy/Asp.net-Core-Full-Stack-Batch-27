import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { JobprovidersComponent } from './jobproviders/jobproviders.component';
import { RegistrationComponent } from './registration/registration.component';

const routes: Routes = [
  { path: 'jobproviders', component: JobprovidersComponent },
  {path: "registration", component: RegistrationComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
