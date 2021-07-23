import { Component } from '@angular/core';

import { ThemeService } from '../services/theme.service';


@Component({
    selector: 'app-nav-menu',
    templateUrl: './nav-menu.component.html',
    styleUrls: ['./nav-menu.component.scss']
})
export class NavMenuComponent {
    public get darkTheme(): boolean { return this.themeService ? this.themeService.darkTheme : false; }
    public isExpanded: boolean = false;


    constructor(public themeService: ThemeService) { }

    public collapse(): void {
        this.isExpanded = false;
    }

    public toggle(): void {
        this.isExpanded = !this.isExpanded;
    }
}