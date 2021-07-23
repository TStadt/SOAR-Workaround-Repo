import { Employee } from './employee.model';
import { Entry } from './entry.model';

export interface Timesheet {
    employee: Employee;
    mondayOfWeek: Date;
    entries: Entry[];
}