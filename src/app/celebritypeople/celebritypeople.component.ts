import { Component, OnInit} from '@angular/core';
import { Router } from '@angular/router';
import { Actor } from "../celebritypeople/shared/celebritypeople.model";
import { ActorService } from "../celebritypeople/shared/celebritypeople.service";
import {  Prize} from "../prize/share/prize.model";
import { PrizeService } from "../prize/share/prize.service";
import {NgForm  } from "@angular/forms";
import {IdActor, Profile} from "./../services/profile"
import{IdPrize} from "./../services/profile"
import { MediaActor } from "../celebritypeople/mediaactor/mediaactor.model";
import { MediaService } from "../celebritypeople/mediaactor/mediaactor.service";
import { PhotoActor } from "../celebritypeople/photoactor/photoactor.model";
import { PhotoActorService } from "../celebritypeople/photoactor/photoactor.service";
import { ActivatedRoute } from "@angular/router";
import {Location} from"@angular/common"
@Component({
    selector: 'app-celebritypeople',
    templateUrl: './celebritypeople.component.html',
    styleUrls: ['./celebritypeople.component.css']
})
export class celebritypeople implements OnInit {
    public actor : Actor
    public prize:Prize
    public mediaactor:  MediaActor
    public photoactor:PhotoActor
    // id: String;
    constructor(private service: ActorService, private serviceprize:PrizeService,private serviceMedia: MediaService, 
      private PhotoService:PhotoActorService, private route:ActivatedRoute,private location:Location) {

    }

    ngOnInit() {
      
      this.getPath();

    }
    resetForm(form:NgForm)
    {
      // form.form.reset();
      this.service.formData=new Actor();
    
    }
    getActorfromRouter():void
    {
    const id=this.route.snapshot.paramMap.get('id')
    console.log(id)
    
   
    }
    goback():void{
      this.location.back();
    }
    async getPath()
    {
      // IdActor.id="Ac01"
      console.log(IdActor.id);

      this.actor = new Actor()
      const movie = await this.service.getList(IdActor.id) as Actor;
      console.log(movie)
      this.actor.ActorId = movie["actorId"]
      this.actor.ActorName=movie["actorName"]
      this.actor.Birth=movie["date"].toString();
      this.actor.Conten_Overview=movie["content_Overview"];
      this.actor.Country=movie["country"];
      this.actor.Image=movie["string"]
      this.actor.PrizeId=movie["prizeID"]
      this.actor.Biography=movie["biography"]
      this.actor.LinkTwiter=movie["linkTwiter"]
      this.actor.Linkfb=movie["linkfb"]
      const prizeDetail=await this.serviceprize.getList(this.actor.PrizeId) as Prize
      // this.prize.prizeId=prizeDetail["prizeId"]
      this.prize=prizeDetail
      this.prize.prizeName=prizeDetail["prize_Name"]
     
      const list=await this.serviceMedia.getList(this.actor.ActorId) as MediaActor
      this.mediaactor=list
      
      const listphot=await this.PhotoService.getList(this.actor.ActorId) as PhotoActor
      this.photoactor=listphot
      console.log(listphot)
      const a=await this.service.postActorDetail()as Actor;
      console.log(a)
     }


      

    
}