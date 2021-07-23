import { Component, OnInit } from '@angular/core';
import { Announcement } from '../interfaces/announcement';

@Component({
  selector: 'app-manage-announcements',
  templateUrl: './manage-announcements.component.html',
  styleUrls: ['./manage-announcements.component.scss']
})
export class ManageAnnouncementsComponent implements OnInit {

    public announcements: Announcement[] = [
        {id: 1, startDate:'7-23-2021', endDate: '7-24-2021', isHighPriority: true, title: 'Title test', body: 'Body test'},
        {id: 2, startDate: '7-23-2021', endDate: '7-25-2021', isHighPriority: false, title: 'Title test 2', body: 'Body test 2'}
    ];
  constructor() { }

  ngOnInit() {
  }

}
