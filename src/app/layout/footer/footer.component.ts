import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
@Component({
    selector: 'app-footer',
    templateUrl: './footer.component.html',
    styleUrls: ['./footer.component.css']
})
//ver của
export class FooterComponent implements OnInit {
    constructor(private router: Router) {}

    ngOnInit() {

    }
    getPath(){
      return this.router.url;
    }
}

