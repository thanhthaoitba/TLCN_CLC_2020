import { Component, OnInit} from '@angular/core';
import { Router } from '@angular/router';

@Component({
    selector: 'app-err',
    templateUrl: './Err404.component.html',
    styleUrls: ['./Err404.component.css']
})
export class Err404 implements OnInit {

    constructor(private router: Router ) {}

    ngOnInit() {
    }
    getPath(){
      return this.router.url;
    }
}