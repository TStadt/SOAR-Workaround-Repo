import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ManageAnnouncementsComponent } from './manage-announcements/manage-announcements.component';
import { ModifyAnnouncementsComponent } from './modify-announcements/modify-announcements.component';
import { TimesheetComponent } from './timesheet/timesheet.component';

const routes: Routes = [
    {
        path: 'home',
        component: HomeComponent,
        pathMatch: 'full'
    },
    {
        path: 'manage-announcements',
        component: ManageAnnouncementsComponent
    },
    {
        path: 'modify-announcements',
        component: ModifyAnnouncementsComponent
    },
    {
        path: 'modify-announcements/:id',
        component: ModifyAnnouncementsComponent
    },
    {
        path: 'timesheets/:week',
        component: TimesheetComponent
    },
    { path: '**', redirectTo: 'home' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
