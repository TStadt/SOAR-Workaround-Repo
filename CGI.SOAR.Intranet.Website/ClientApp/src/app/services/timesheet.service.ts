import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators'
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Task } from '../interfaces/task.model';
import { Timesheet } from '../interfaces/timesheet.model';
import * as moment from 'moment';


const ROOT_ENDPOINT: string = 'api/TimeSheet';

@Injectable({
    providedIn: 'root'
})
export class TimesheetService {
    constructor(private http: HttpClient, @Inject('WEBAPI_URL') private webApiUrl: string) { }

    public getTasks(): Observable<Task[]> {
        return this.http.get<Task[]>(`${this.webApiUrl}${ROOT_ENDPOINT}/tasks`);
    }

    public getTimeSheet(weekOffset: number): Observable<Timesheet> {
        let dateInWeek: string = moment().add(weekOffset, 'weeks').format();
        
        return this.http.get<Timesheet>(`${this.webApiUrl}${ROOT_ENDPOINT}/${dateInWeek}`);
    }

    public submitTimeSheet(timesheet: Timesheet): Observable<boolean> {
        return this.http.post(`${this.webApiUrl}${ROOT_ENDPOINT}`, timesheet, { observe: 'response' }).pipe((map((res: HttpResponse<boolean>) => {
            return res.ok;
        })) as any);
    }

    public validateTimeSheet(timesheet: Timesheet): Observable<HttpResponse<any>> {
        return this.http.post(`${this.webApiUrl}${ROOT_ENDPOINT}/validate`, timesheet, { observe: 'response' });
    }
}