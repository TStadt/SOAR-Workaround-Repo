import { HttpClient } from '@angular/common/http';
import { Inject, Injectable, RootRenderer } from '@angular/core';
import { inject } from '@angular/core/testing';
import { Observable } from 'rxjs';
import { Announcement } from '../interfaces/announcement';

const ROOT_ENDPOINT: string = 'api/Announement';

@Injectable({
    providedIn: 'root'
})
export class AnnouncementsService {

    constructor(private httpClient: HttpClient, @Inject('WEBAPI_URL') private _webAPIUrl: string) { }

    public createAnnouncement(announcement: Announcement): Observable<Announcement>{
        return this.httpClient.post<Announcement>(`${this._webAPIUrl}${ROOT_ENDPOINT}`, announcement);
    }

    public updateAnnouncement(announcement: Announcement): Observable<Announcement> {
        return this.httpClient.put<Announcement>(`${this._webAPIUrl}${ROOT_ENDPOINT}`, announcement);
    }

    // This may be incorrect, should this be a list of objects?
    public removeAnnouncement(id: number): Observable<Announcement[]> {
        return this.httpClient.delete<Announcement[]>(`${this._webAPIUrl}${ROOT_ENDPOINT}/${id}`);
    }

    public getActiveAnnouncements(): Observable<Announcement[]> {
        return this.httpClient.get<Announcement[]>(`${this._webAPIUrl}${ROOT_ENDPOINT}`);
    }

    public getAllAnnouncements(): Observable<Announcement[]> {
        return this.httpClient.get<Announcement[]>(`${this._webAPIUrl}${ROOT_ENDPOINT}`);
    }
}
