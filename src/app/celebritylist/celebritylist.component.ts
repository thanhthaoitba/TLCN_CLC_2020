import { Component, OnInit} from '@angular/core';
import { Router } from '@angular/router';
import {NgForm  } from "@angular/forms";
import {IdActor} from "./../services/profile"
import { Actor } from "../celebritypeople/shared/celebritypeople.model";
import { ActorService } from "../celebritypeople/shared/celebritypeople.service";


@Component({
    selector: 'app-celeritylist',
    templateUrl: './celebritylist.component.html',
    styleUrls: ['./celebritylist.component.css']
})
export class celebritylist implements OnInit {

  public list:Actor

    constructor(private service:ActorService ,private router:Router) {}

    ngOnInit() {
      this.getPath();
    }
     async getPath(){
      const a= await this.service.postActorDetail() as Actor;      
      this.list=a
      console.log(a)
    }
    resetForm(form:NgForm)
    {
      form.form.reset();
      this.service.formData=new Actor();
    
    }
    public onClick= async (id)=>{
      IdActor.id=id;
      console.log(IdActor.id);
      this.router.navigate(['/FamousPeople/', IdActor.id]);
    }
}