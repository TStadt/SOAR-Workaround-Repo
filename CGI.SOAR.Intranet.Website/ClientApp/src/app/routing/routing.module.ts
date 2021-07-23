import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from '../home/home.component';
import { ManageAnnouncementsComponent } from '../manage-announcements/manage-announcements.component';
import { ModifyAnnouncementComponent } from '../modify-announcement/modify-announcement.component';
import { TimesheetComponent } from '../timesheet/timesheet.component';


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
        path: 'modify-announcement',
        component: ModifyAnnouncementComponent
    },
    {
        path: 'modify-announcement/:id',
        component: ModifyAnnouncementComponent
    },
    {
        path: 'timesheets/:weekOffset',
        component: TimesheetComponent
    },
    { path: '**', redirectTo: 'home' }
];

@NgModule({
    declarations: [],
    imports: [
        CommonModule,
        RouterModule.forRoot(routes)
    ],
    exports: [
        RouterModule
    ]
})
export class RoutingModule { }