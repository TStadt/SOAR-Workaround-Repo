import { Injectable } from '@angular/core';


@Injectable({
    providedIn: 'root'
})
export class ThemeService {
    public darkTheme: boolean = false;
}