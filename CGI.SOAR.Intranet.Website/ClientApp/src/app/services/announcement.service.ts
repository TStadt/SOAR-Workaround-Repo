import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { Announcement } from '../interfaces/announcement.model';


const ROOT_ENDPOINT: string = 'api/Announcement';

@Injectable()
export class AnnouncementService {
    constructor(private httpClient: HttpClient, @Inject('WEBAPI_URL') private _webApiUrl: string) { }

    public getActiveAnnouncements(): Observable<Announcement[]> {
        return this.httpClient.get<Announcement[]>(`${this._webApiUrl}${ROOT_ENDPOINT}/active`);
    }

    public getAnnouncementById(id: number): Observable<Announcement> {
        return this.httpClient.get<Announcement>(`${this._webApiUrl}${ROOT_ENDPOINT}/${id}`);
    }

    public deleteAnnouncement(id: number): Observable<Announcement[]> {
        return this.httpClient.delete<Announcement[]>(`${this._webApiUrl}${ROOT_ENDPOINT}/${id}`);
    }

    public getAllAnnouncements(): Observable<Announcement[]> {
        return this.httpClient.get<Announcement[]>(`${this._webApiUrl}${ROOT_ENDPOINT}`);
    }

    public addAnnouncement(announcement: Announcement): Observable<Announcement> {
        return this.httpClient.post<Announcement>(`${this._webApiUrl}${ROOT_ENDPOINT}`, announcement);
    }

    public updateAnnouncement(announcement: Announcement): Observable<Announcement> {
        return this.httpClient.put<Announcement>(`${this._webApiUrl}${ROOT_ENDPOINT}`, announcement);
    }
}