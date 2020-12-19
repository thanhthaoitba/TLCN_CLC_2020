import { Component, OnInit} from '@angular/core';
import { Router } from '@angular/router';
import { Blog } from "./share/blogdetail.model";
import { BlogService } from "./share/blogdetail.service";
import {NgForm  } from "@angular/forms";
import { IdBlog } from "../services/profile";
@Component({
    selector: 'app-home',
    templateUrl: './blogdetail.component.html',
    styleUrls: ['./blogdetail.component.css']
})
export class blogdetail implements OnInit {
  public blog:Blog
    constructor(private service: BlogService ) {}

    ngOnInit() {
      IdBlog.id="" // Get By Id
      this.getPath();
    }
    async getPath(){
      this.blog=new Blog()
      const detail=await this.service.getList(IdBlog.id) as any;
      this.blog.blogId=detail["BlogId"]
      this.blog.blog_title=detail["Title"]
      this.blog.content=detail["Content"]
      this.blog.image=detail["Image"]
    }
    resetForm(form:NgForm)
    {
      form.form.reset();
      this.service.formData=new Blog()
    }
    
}