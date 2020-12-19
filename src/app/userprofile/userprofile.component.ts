import { Component, OnInit} from '@angular/core';
import { Router } from '@angular/router';
import {NgForm  } from "@angular/forms";
import {IdUser  } from "../services/profile";
import {User  } from "./share/userprofile.model";
import {  UserService} from "./share/userprofile.service";
@Component({
    selector: 'app-user',
    templateUrl: './userprofile.component.html',
    styleUrls: ['./userprofile.component.css']
})
export class userprofile implements OnInit {

  public User:User
  
    constructor(private service: UserService ) {}

    ngOnInit() {
      IdUser.id=""
      this.getPath()
    }
    async getPath()
    {
     this.User=new User()
     const detail=await this.service.getList(IdUser.id) as any
      this.User.userId=detail["userId"]
      this.User.userName=detail["Name"]
      this.User.Country=detail["Country"]
      this.User.Email=detail["Email"]
      this.User.Password=detail["Password"]
      this.User.Image=detail["Image"]
    }
    resetForm(form:NgForm)
    {
      form.form.reset();
      this.service.formData=new User();
    }
}
