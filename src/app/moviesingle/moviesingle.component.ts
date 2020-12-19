import { Component, OnInit} from '@angular/core';
import { Router } from '@angular/router';
import { Type } from "../type/share/type.model";
import { TypeService } from "../type/share/type.service";
@Component({
    selector: 'app-home',
    templateUrl: './moviesingle.component.html',
    styleUrls: ['./moviesingle.component.css']
})
export class moviesingle implements OnInit {

    constructor(private router: Router ) {}

    ngOnInit() {
    }
    getPath(){
      return this.router.url;
    }
}
