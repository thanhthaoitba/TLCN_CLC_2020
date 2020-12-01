import { Component, OnInit} from '@angular/core';
import { Router } from '@angular/router';

@Component({
    selector: 'app-home',
    templateUrl: './userfavoritieslist.component.html',
    styleUrls: ['./userfavoritieslist.component.css']
})
export class userfavoritieslist implements OnInit {

    constructor(private router: Router ) {}

    ngOnInit() {
    }
    getPath(){
      return this.router.url;
    }
}
