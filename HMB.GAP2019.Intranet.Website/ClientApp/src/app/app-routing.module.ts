import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { ManageAnnouncementsComponent } from './manage-announcements/manage-announcements.component';
import { ModifyAnnouncementComponent } from './modify-announcement/modify-announcement.component';
import { TimesheetComponent } from './timesheet/timesheet.component';

const routes: Routes = [
  { path: 'manage-announcements', component: ManageAnnouncementsComponent },
  { path: 'modify-announcement', component: ModifyAnnouncementComponent },
  { path: 'timesheet', component: TimesheetComponent },
  {path: '', component: AppComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
