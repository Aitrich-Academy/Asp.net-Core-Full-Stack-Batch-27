import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SettingsComponent } from './settings/settings.component';
import { LoginComponent } from './login/login.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { FooterComponent } from './footer/footer.component';
import { JobListComponent } from './job-list/job-list.component';
import { FormsModule, ReactiveFormsModule} from '@angular/forms';
import { JobService } from './job.service';

@NgModule({
  declarations: [
    AppComponent,
    SettingsComponent,
    LoginComponent,
    SidebarComponent,
    FooterComponent,
    JobListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule
    
  ],
  providers: [JobService],
  bootstrap: [AppComponent]
})
export class AppModule { }
