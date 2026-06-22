import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { FooterComponent } from './footer/footer.component';
import { SecondFooterComponent } from './second-footer/second-footer.component';
import { HeaderComponent } from './header/header.component';
import { AllJobsComponent } from './all-jobs/all-jobs.component';
import { ChildComponent } from './child/child.component';


@NgModule({
  declarations: [
    AppComponent,
    SidebarComponent,
    FooterComponent,
    SecondFooterComponent,
    HeaderComponent,
    AllJobsComponent,
    ChildComponent,
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
