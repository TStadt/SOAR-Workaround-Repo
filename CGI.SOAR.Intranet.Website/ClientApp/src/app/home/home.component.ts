import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { Converter } from 'showdown';

import { Announcement } from '../interfaces/announcement.model';
import { AnnouncementService } from '../services/announcement.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html'
})
export class HomeComponent implements OnDestroy, OnInit {
  private _subscriptions: Subscription[] = [];
  private _converter = new Converter();

  public announcements: Announcement[] = [];

  constructor(private _announcementService: AnnouncementService) { }

  public ngOnDestroy(): void {
    this._subscriptions.forEach(s => s.unsubscribe());
  }

  public ngOnInit() {
    const messageSubscription = this._announcementService.getActiveAnnouncements()
      .subscribe(list => {
        this.announcements = list.map(a => {
          var body = this._converter.makeHtml(a.body);
          return { ...a, body }
        });
      });

    this._subscriptions = [messageSubscription];
  }
}
