import {Blog  } from "./blogdetail.model";
import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
@Injectable({
    providedIn:'root'
})
export class BlogService{
    formData:Blog=new Blog();
    private baseURL='/api/Blog';
    list:Blog[];
    constructor(private http:HttpClient){}
    getBloglist(){
        return this.http.post(this.baseURL, this.formData);
    }
    putBlogDetail(){
        return this.http.put(`${this.baseURL}/${this.formData.blogId}`,this.formData);

    }
    deleteBlogDetail(id:string)
    {
        return this.http.delete(`${this.baseURL}/${id}`)
    }
    refreshList(){
        this.http.get(this.baseURL)
        .toPromise()
        .then(res=>this.list=res as Blog[]);
    }
    getList = async (id) => {
        try {

            const result = await this.http.get(this.baseURL+"/"+id).toPromise();
            console.log(result)
            return result;
        }
        catch (e) {
            console.log(e);
            // this.removeToken();
        }
    }
    getblogdetail=async ()=>
    {
        try {

            const result = await this.http.get(this.baseURL).toPromise();
            console.log(result)
            return result;
        }
        catch (e) {
            console.log(e);
            // this.removeToken();
        }
    }
}