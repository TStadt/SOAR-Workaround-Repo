import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ModifyAnnouncementComponent } from './modify-announcement/modify-announcement.component';
import { ManageAnnouncementsComponent } from './manage-announcements/manage-announcements.component';
import { TimesheetComponent } from './timesheet/timesheet.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';

@NgModule({
  declarations: [
    AppComponent,
    ModifyAnnouncementComponent,
    ManageAnnouncementsComponent,
    TimesheetComponent,
    NavBarComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    AppRoutingModule
  ],
  providers: [
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
