import { Component, OnInit} from '@angular/core';
import { Router } from '@angular/router';

@Component({
    selector: 'app-home',
    templateUrl: './celebritypeople.component.html',
    styleUrls: ['./celebritypeople.component.css']
})
export class celebritypeople implements OnInit {

    constructor(private router: Router ) {}

    ngOnInit() {
    }
    getPath(){
      return this.router.url;
    }
}