import { Component } from '@angular/core';

import { ThemeService } from './services/theme.service';


@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.scss']
})
export class AppComponent {
    public get darkTheme(): boolean { return this.themeService ? this.themeService.darkTheme : false; }
    

    constructor(private themeService: ThemeService) { }
}