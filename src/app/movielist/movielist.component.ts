import { Component, OnInit} from '@angular/core';
import { Router } from '@angular/router';
import {  MovieDetail} from "../moviesingle/share/moviesingle.model";
import {MovieDetailService } from "../moviesingle/share/moviesingle.service";
import { IdMovie } from "../services/profile";
@Component({
    selector: 'app-movie-list',
    templateUrl: './movielist.component.html',
    styleUrls: ['./movielist.component.css']
})
export class movielist implements OnInit {

  public list:MovieDetail
    constructor(private router: Router , private service:MovieDetailService) {}

    public onClick= async (id)=>{
      IdMovie.id=id;
      console.log(IdMovie.id);
      this.router.navigate(['/Movie/', IdMovie.id]);
    }
    ngOnInit() {
      this.getPath()
    }
    async getPath(){

      const a=await this.service.getListfull() as MovieDetail
      this.list=a
      console.log(a)
    }
}
