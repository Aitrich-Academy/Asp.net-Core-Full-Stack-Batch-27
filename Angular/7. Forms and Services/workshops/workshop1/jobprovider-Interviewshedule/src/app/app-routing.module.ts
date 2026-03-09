import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegistrationFormComponent } from './registration-form/registration-form.component';
import { RemoveRegistrationDetailsComponent } from './remove-registration-details/remove-registration-details.component';



const routes: Routes = [
 
  { path: '', redirectTo: '/registration-form', pathMatch: 'full' },
  { path: 'registration-form', component: RegistrationFormComponent },
  { path: 'remove-registered-details', component: RemoveRegistrationDetailsComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
