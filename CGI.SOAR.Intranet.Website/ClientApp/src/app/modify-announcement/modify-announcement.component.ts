import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, ParamMap } from '@angular/router';

import { Announcement } from '../interfaces/announcement.model';
import { AnnouncementService } from '../services/announcement.service';
import { ThemeService } from '../services/theme.service';


@Component({
    selector: 'app-modify-announcement',
    templateUrl: './modify-announcement.component.html',
    styleUrls: ['./modify-announcement.component.scss']
})
export class ModifyAnnouncementComponent implements OnInit {
    public get darkTheme(): boolean { return this.themeService ? this.themeService.darkTheme : false; }

    public announcement: Announcement = {
        isHighPriority: false,
        title: '',
        body: '',
        endDate: '',
        startDate: ''
    };


    constructor(
        private announcementService: AnnouncementService,
        private themeService: ThemeService,
        private route: ActivatedRoute,
        private router: Router) { }

    public ngOnInit(): void {
        this.route.paramMap.subscribe((params: ParamMap): void => {
            if (params.has('id')) {
                this.announcementService.getAnnouncementById(+params.get('id')).subscribe((announcement: Announcement): void => {
                    this.announcement = announcement;
                });
            }
        });
    }

    public addAnnouncement() {
        this.announcementService.addAnnouncement(this.announcement).subscribe((): void => {
            this.router.navigate(['/manageAnnouncements']);
        }, this.onAnnouncementError);
    }

    public updateAnnouncement() {
        this.announcementService.updateAnnouncement(this.announcement).subscribe((): void => {
            this.router.navigate(['/manageAnnouncements']);
        }, this.onAnnouncementError);
    }

    private onAnnouncementError(error: any): void {
        let errorMessages: string[] = [];

        for (let prop in error.error) {
            errorMessages.push('\"' + prop + '\" is required');
        }

        alert('Error: announcement is not valid | ' + errorMessages.join('; '));
    }
}