import { Component, OnInit} from '@angular/core';
import { Router } from '@angular/router';
import { Type } from "../type/share/type.model";
import { TypeService } from "../type/share/type.service";
import {  MovieActor, MovieDetail, MovieType} from "../moviesingle/share/moviesingle.model";
import {  MovieDetailService} from "../moviesingle/share/moviesingle.service";
import {Location} from "@angular/common"
import { IdMovie } from '../services/profile';
import { Actor } from "../celebritypeople/shared/celebritypeople.model";
import { ActorService } from "../celebritypeople/shared/celebritypeople.service";
import {  DirectorService} from "../director/share/directordetail.service";
import { Director } from "../director/share/directordetail.model";
import { Prize } from "../prize/share/prize.model"
import { PrizeService } from "../prize/share/prize.service";
import { Productor } from "../productor/share/productor.model";
import {  ProductorService} from "../productor/share/productor.service";

@Component({
    selector: 'app-moviesingle',
    templateUrl: './moviesingle.component.html',
    styleUrls: ['./moviesingle.component.css']
})
export class moviesingle implements OnInit {

public movie:MovieDetail
public actor:Actor[]=[];
public movieactor:MovieActor
public movietype:MovieType
public type:Type[]=[];
public director:Director;
public productor:Productor;
public prize:Prize
    constructor(private router: Router, private location:Location ,
      private movies:MovieDetailService, private Typeservice:TypeService,
       private GetActor:ActorService, private directorservice:DirectorService,
       private productorservice:ProductorService,
       private prizeservice:PrizeService) {}

    ngOnInit() {
      IdMovie.id='Mv01'
      this.getPath()
    }
    async getPath(){
      this.movie=new MovieDetail();
      this.movieactor=new MovieActor();
      this.director=new Director();
      this.productor=new Productor();
      this.prize=new Prize();
      const detail=await this.movies.getList(IdMovie.id) as any // lay thong tin movie 
      this.movie=detail
      console.log(this.movie)
      const list=await this.movies.getListActorFromMovie(this.movie.movieId) as any // lay list actor tu movieId
      this.movieactor=list;
    
      console.log(Object.keys(list).length)

    
      for(let i=0;i<Object.keys(list).length;i++)
      {
        const detailActor=await this.GetActor.getList(this.movieactor[i].actorId) as any // get detail
        this.actor[i]=detailActor
      }
      console.log(this.actor)
      
      const listtype=await this.movies.getListTypeFromMovie(this.movie.movieId) as any
     this.movietype=listtype
      for(let i=0;i<Object.keys(listtype).length;i++)
      {
        const detailType=await this.Typeservice.getList(this.movietype[i].typeId) as any
         this.type[i]=detailType
      }
       console.log(this.type)
       this.productor=await this.productorservice.getList(this.movie.ProductorID) as any
       this.director=await this.directorservice.getList(this.movie.DirectorID) as any
       this.prize=await this.prizeservice.getList(this.movie.PrizeId) as any
      //chay vong for cho tung actorid 
      // su dung lai actor service 
      // cho nay la phai tao mot list actor o day 
    }
    goback():void{
      this.location.back();
    }
}
