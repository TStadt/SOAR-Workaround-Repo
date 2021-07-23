import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AnnouncementService } from './services/announcement.service';
import { TimesheetService } from './services/timesheet.service';
import { ThemeService } from './services/theme.service';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { ManageAnnouncementsComponent } from './manage-announcements/manage-announcements.component';
import { ModifyAnnouncementComponent } from './modify-announcement/modify-announcement.component';
import { TimesheetComponent } from './timesheet/timesheet.component';
import { RoutingModule } from './routing/routing.module';


@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        ManageAnnouncementsComponent,
        ModifyAnnouncementComponent,
        TimesheetComponent
    ],
    imports: [
        BrowserModule,
        HttpClientModule,
        FormsModule,
        RoutingModule
    ],
    providers: [
        AnnouncementService,
        TimesheetService,
        ThemeService
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }