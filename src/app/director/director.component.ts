import { Component, OnInit} from '@angular/core';
import { Router } from '@angular/router';
import {NgForm  } from "@angular/forms";
import {IdDirector, Profile} from "./../services/profile"
import {  DirectorService} from "../director/share/directordetail.service";
import { Director } from "../director/share/directordetail.model";
import { Prize } from "../prize/share/prize.model"
import { PrizeService } from "../prize/share/prize.service";

@Component({
    selector: 'app-actor-detail-form',
    templateUrl: './director.component.html',
    styleUrls: ['./director.component.css']
})
export class DirectorDetail implements OnInit {
    public Director : Director
    public Prize: Prize
    constructor(private service: DirectorService, private PrizeService: PrizeService) {
    }

    ngOnInit() {
     IdDirector.Id="Dr01"//Get by id 
      this.getPath()
      
    }
    resetForm(form:NgForm)
    {
      form.form.reset();
      this.service.formData=new Director();
    }
    async getPath(){
      this.Director = new Director()
      const movie = await this.service.getList(IdDirector.Id) as any;
      // this.Director.DirectorId = movie["directorsId"]
      this.Director.DirectorName=movie["directors_Name"]
      this.Director.Content_Overview=movie["content_Overview"];
      this.Director.Image=movie["image"]
      this.Director.PrizeId=movie["prizeId"]
      this.Prize=new Prize()
      const a=await this.PrizeService.getList(this.Director.PrizeId) as any;
      this.Prize.prizeId=a["prizeId"]
      this.Prize.prizeName=a["prize_Name"]
    

    }
}