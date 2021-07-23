import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { TimesheetService } from '../services/timesheet.service';
import { Timesheet } from '../interfaces/timesheet.model';
import { Entry } from '../interfaces/entry.model';
import { Task } from '../interfaces/task.model';
import { ThemeService } from '../services/theme.service';


type day = 'monday' | 'tuesday' | 'wednesday' | 'thursday' | 'friday' | 'saturday' | 'sunday';

const DEFAULT_NEW_ENTRY: Entry = {
    monday: 0,
    tuesday: 0,
    wednesday: 0,
    thursday: 0,
    friday: 0,
    saturday: 0,
    sunday: 0,
    assignedTask: {
        id: -1,
        name: '',
        isNoteRequired: false
    },
    note: ''
};
const TASK_OPTIONS: Task[] = [
    { id: 1, name: 'Deployment', isNoteRequired: false },
    { id: 2, name: 'Design', isNoteRequired: false },
    { id: 3, name: 'Develop', isNoteRequired: false },
    { id: 4, name: 'Marketing', isNoteRequired: false },
    { id: 5, name: 'Meeting', isNoteRequired: false },
    { id: 6, name: 'Other', isNoteRequired: true },
    { id: 7, name: 'Out of Office', isNoteRequired: false },
    { id: 8, name: 'Project Management', isNoteRequired: false },
    { id: 9, name: 'Release Management', isNoteRequired: false },
    { id: 10, name: 'Requirements', isNoteRequired: false },
    { id: 11, name: 'Testing', isNoteRequired: false }
];

@Component({
    selector: 'app-timesheet',
    templateUrl: './timesheet.component.html',
    styleUrls: ['./timesheet.component.scss']
})
export class TimesheetComponent implements OnInit {
    public timesheet: Timesheet;
    public newEntry: Entry = DEFAULT_NEW_ENTRY;

    public get darkTheme(): boolean { return this.themeService ? this.themeService.darkTheme : false; }

    public get mondaysSum(): number { return this.getDaySum('monday'); }
    public get tuesdaysSum(): number { return this.getDaySum('tuesday'); }
    public get wednesdaysSum(): number { return this.getDaySum('wednesday'); }
    public get thursdaysSum(): number { return this.getDaySum('thursday'); }
    public get fridaysSum(): number { return this.getDaySum('friday'); }
    public get saturdaysSum(): number { return this.getDaySum('saturday'); }
    public get sundaysSum(): number { return this.getDaySum('sunday'); }

    public get taskOptions(): Task[] { return TASK_OPTIONS; }
    public get days(): day[] { return ['monday', 'tuesday', 'wednesday', 'thursday', 'friday', 'saturday', 'sunday']; }
    public get newEntrySum(): number { return this.getEntrySum(this.newEntry); }
    public get entriesSums(): number[] {
        let sums: number[] = [];

        for (let entry of this.timesheet.entries) {
            sums.push(this.getEntrySum(entry));
        }

        return sums;
    }

    public get tasks(): Task[] {
        let tasks: Task[] = Object.assign([], TASK_OPTIONS);

        for (let i: number = 0; i < this.timesheet.entries.length; i++) {
            let entry: Entry = this.timesheet.entries[i];

            for (let j: number = tasks.length - 1; j >= 0; j--) {
                if (entry.assignedTask.id == tasks[j].id) {
                    tasks.splice(j, 1);
                    break;
                }
            }
        }

        return tasks;
    }

    public weekOffset: number = 0;



    constructor(
        private timesheetService: TimesheetService,
        private themeService: ThemeService,
        private route: ActivatedRoute) { }

    public ngOnInit(): void {
        this.route.paramMap.subscribe((params) => {
            this.weekOffset = parseInt(params['params']['weekOffset']);
            this.timesheetService.getTimeSheet(this.weekOffset).subscribe((timesheet: Timesheet): void => {
                this.timesheet = timesheet;
            });
        });
    }

    public save(): void {
        this.timesheetService.validateTimeSheet(this.timesheet).subscribe((): void => {
            this.timesheetService.submitTimeSheet(this.timesheet).subscribe((isValid: boolean): void => {
                if (isValid) {
                    alert('Submitted');
                } else {
                    alert('Valid but not submitted');
                }
            });
        }, (error: any): void => {
            let errorMessages: string[] = [];

            for (let prop in error.error) {
                errorMessages.push(prop);
            }

            alert('Error: timesheet is not valid | ' + errorMessages.join(' '));
        });
    }

    public addEntry(): void {
        // Object.assign is used to prevent referencing issues
        this.timesheet.entries.push(Object.assign({}, <any>this.newEntry));
        this.newEntry = {
            monday: 0,
            tuesday: 0,
            wednesday: 0,
            thursday: 0,
            friday: 0,
            saturday: 0,
            sunday: 0,
            assignedTask: {
                id: -1,
                name: '',
                isNoteRequired: false
            },
            note: ''
        };
    }

    public deleteEntry(entryIndex: number): void {
        this.timesheet.entries.splice(entryIndex, 1);
    }

    public entriesSum(entryIndex: number): number {
        let entry: Entry = this.timesheet.entries[entryIndex];

        return entry.monday +
            entry.tuesday +
            entry.wednesday +
            entry.thursday +
            entry.friday +
            entry.saturday +
            entry.sunday;
    }

    public getEntrySum(entry: Entry): number {
        return entry.monday +
            entry.tuesday +
            entry.wednesday +
            entry.thursday +
            entry.friday +
            entry.saturday +
            entry.sunday;
    }

    public getDaySum(dayName: string): number {
        let sum: number = 0;

        for (let i: number = 0; i < this.timesheet.entries.length; i++) {
            sum += this.timesheet.entries[i][dayName];
        }

        return sum + (this.newEntry ? this.newEntry[dayName] : 0);
    }

    public log(...args): void { console.log(...args); }

    public parseInt(value: string): number { return parseInt(value); }

    public stringify(value: any): string { return JSON.stringify(value); }

    public compareTasksById(task1: Task, task2: Task): boolean { return task1 && task2 && task1.id == task2.id; }

    public formatDate(dayOffset: number): string {
        let date: Date = new Date(this.timesheet.mondayOfWeek);
        let newDay: number = date.getUTCDay() + dayOffset;

        if (newDay > 6) {
            newDay -= 7;
        }

        return this.getDayOfWeek(newDay).substring(0, 2) + ' ' + (date.getUTCMonth() + 1) + '/' + (date.getUTCDate() + dayOffset);
    }

    public getDayOfWeek(dayIndex: number): string {
        switch (dayIndex) {
            case 0: return 'Sunday';
            case 1: return 'Monday';
            case 2: return 'Tuesday';
            case 3: return 'Wednesday';
            case 4: return 'Thursday';
            case 5: return 'Friday';
            case 6: return 'Saturday';
            default: return 'Unknown day';
        }
    }
}