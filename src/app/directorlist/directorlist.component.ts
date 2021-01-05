import { Component, OnInit} from '@angular/core';
import { Router } from '@angular/router';
import {NgForm  } from "@angular/forms";
import {IdDirector} from "./../services/profile"
import{Director } from "../director/share/directordetail.model"
import{ DirectorService} from "../director/share/directordetail.service"

@Component({
    selector: 'app-DirectorList',
    templateUrl: './directorlist.component.html',
    styleUrls: ['./directorlist.component.css']
})
export class DirectorList implements OnInit {

  public list:Director

    constructor(private service:DirectorService ,private router:Router) {}

    ngOnInit() {
      this.getPath();
    }
     async getPath(){
      const a= await this.service.getListfull()  as Director;
      this.list=a
      console.log(this.list)
    }
    resetForm(form:NgForm)
    {
      form.form.reset();
      this.service.formData=new Director();
    
    }
    public onClick= async (id)=>{
      IdDirector.Id=id;
      console.log(IdDirector.Id);
      this.router.navigate(['/DirectorDetail/', IdDirector.Id]);
    }
}