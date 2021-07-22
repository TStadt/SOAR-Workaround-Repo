import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { ManageAnnouncementsComponent } from './manage-announcements/manage-announcements.component';
import { ModifyAnnouncementsComponent } from './modify-announcements/modify-announcements.component';
import { TimesheetComponent } from './timesheet/timesheet.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ManageAnnouncementsComponent,
    ModifyAnnouncementsComponent,
    TimesheetComponent,
    NavMenuComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    AppRoutingModule
  ],
  providers: [
  ],
  bootstrap: [AppComponent],
  exports: [HomeComponent, ManageAnnouncementsComponent, ModifyAnnouncementsComponent, TimesheetComponent, NavMenuComponent]
})
export class AppModule { }
