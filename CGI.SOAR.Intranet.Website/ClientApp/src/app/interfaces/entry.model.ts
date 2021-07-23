import { Task } from './task.model';

export interface Entry {
  assignedTask: Task,
  monday: number,
  tuesday: number,
  wednesday: number,
  thursday: number,
  friday: number,
  saturday: number,
  sunday: number,
  note: string
}
