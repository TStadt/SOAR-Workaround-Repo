import { Component, OnInit, Input } from '@angular/core';

import { Announcement } from '../interfaces/announcement.model';
import { AnnouncementService } from '../services/announcement.service';
import { ThemeService } from '../services/theme.service';


@Component({
    selector: 'app-manage-announcements',
    templateUrl: './manage-announcements.component.html',
    styleUrls: ['./manage-announcements.component.scss']
})
export class ManageAnnouncementsComponent implements OnInit {
    public get darkTheme(): boolean { return this.themeService ? this.themeService.darkTheme : false; }
    public announcements: Announcement[] = [];


    constructor(
        private announcementService: AnnouncementService,
        private themeService: ThemeService) { }

    public ngOnInit(): void {
        this.announcementService.getAllAnnouncements().subscribe((list: Announcement[]): void => {
            this.announcements = list;
        });
    }

    public deleteAnnouncement(id: number) {
        console.log(id);
        this.announcementService.deleteAnnouncement(id).subscribe((): void => {
            this.getAnnouncements();
        });
    }

    public getAnnouncements() {
        this.announcementService.getAllAnnouncements().subscribe((announcements: Announcement[]): void => {
            this.announcements = announcements;
        });
    }
}