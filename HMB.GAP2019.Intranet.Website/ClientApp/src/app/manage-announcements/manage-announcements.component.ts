import { Component, OnInit } from '@angular/core';
import { Announcement } from '../interfaces/announcement';

@Component({
  selector: 'app-manage-announcements',
  templateUrl: './manage-announcements.component.html',
  styleUrls: ['./manage-announcements.component.scss']
})
export class ManageAnnouncementsComponent implements OnInit {

    public announcements: Announcement[] = [];
  constructor() { }

  ngOnInit() {
  }

}
