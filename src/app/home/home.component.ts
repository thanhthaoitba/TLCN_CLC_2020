import { Component, OnInit} from '@angular/core';
import { Router } from '@angular/router';
import { ConfigService } from '../apis/config.service';
import { HttpClient } from '@angular/common/http';


export interface Config {
  heroesUrl: string;
  textfile: string;
}
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
// export interface Config {
//   heroesUrl: string;
//   textfile: string;
// }

export class HomeComponent implements OnInit {

    constructor(private router: Router ) {}
    showConfig() {
      // this.CallAPI.
      console.log("=====================")
      const configService = new ConfigService()
      configService.getRequests("").then((e)=>{
        console.log("mmmmmmmmm",e)
      })
      // ConfigService.getConfig()
      // .subscribe((data: Config) => this.config = {
      //     heroesUrl: data.heroesUrl,
      //     textfile:  data.textfile
      // });
    }
    ngOnInit() {
      // console.log(this.showConfig())
      this.showConfig()
    }
    getPath(){
      return this.router.url;
    }
}
