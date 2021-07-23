export interface Announcement {
    isHighPriority: boolean;
    title: string;
    body: string;
    id?: number;
    startDate: string;
    endDate: string;
}
