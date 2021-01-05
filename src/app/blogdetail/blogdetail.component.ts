import { Component, OnInit} from '@angular/core';
import { Router } from '@angular/router';
import { Blog } from "./share/blogdetail.model";
import { BlogService } from "./share/blogdetail.service";
import {NgForm  } from "@angular/forms";
import { IdBlog } from "../services/profile";
import {Location} from "@angular/common"
@Component({
    selector: 'app-blogdetail',
    templateUrl: './blogdetail.component.html',
    styleUrls: ['./blogdetail.component.css']
})
export class blogdetail implements OnInit {
  public blog:Blog
    constructor(private service: BlogService ,private location:Location) {}

    ngOnInit() {
     // Get By Id
      this.getPath();
    }
    async getPath(){
      this.blog=new Blog()
      const detail=await this.service.getList(IdBlog.id) as any;
      this.blog=detail  
      this.blog.blog_title=detail["title"]
      console.log(detail)
    }
    resetForm(form:NgForm)
    {
      form.form.reset();
      this.service.formData=new Blog()
    }
    goback():void{
      this.location.back();
    }
    
    
}