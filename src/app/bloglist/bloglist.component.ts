import { Component, OnInit} from '@angular/core';
import { Router } from '@angular/router';
import {Blog} from '../blogdetail/share/blogdetail.model'
import { BlogService } from "../blogdetail/share/blogdetail.service";
import { IdBlog } from "../services/profile";
@Component({
    selector: 'app-bloglist',
    templateUrl: './bloglist.component.html',
    styleUrls: ['./bloglist.component.css']
})
export class bloglist implements OnInit {

  public list:Blog;
    constructor(private router: Router, private service: BlogService ) {}

    ngOnInit() {
      this.getPath()
    }
  
    public onClick= async (id)=>{
      IdBlog.id=id;
      console.log(IdBlog.id);
      this.router.navigate(['/BlogDetail/', IdBlog.id]);
    }
    async getPath(){
      const a= await this.service.getblogdetail() as Blog      
      this.list=a
      console.log(a)
    }
}