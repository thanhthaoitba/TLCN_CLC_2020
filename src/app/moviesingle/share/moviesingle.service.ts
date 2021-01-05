import { MovieDetail } from "./moviesingle.model";
import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { IdMovie } from "../../services/profile";
import { async } from "rxjs/internal/scheduler/async";
@Injectable({
    providedIn:'root'
})
export class MovieDetailService{
    formData:MovieDetail=new MovieDetail();
    private baseURL='/api/Movie';
    private URLActor='api/MovieActor/GetListActorFromMovie/';
    private URLType='api/TypeMovie/GetTypeFromMovie/';
    list:MovieDetail[];
    constructor(private http:HttpClient){}
    postDirectorDetail(){
        return this.http.post(this.baseURL, this.formData);
    }
    putDirectorDetail(){
        return this.http.put(`${this.baseURL}/${this.formData.movieId}`,this.formData);

    }
    deleteDirectorDetail(id:string)
    {
        return this.http.delete(`${this.baseURL}/${id}`)
    }
    refreshList(){
        this.http.get(this.baseURL)
        .toPromise()
        .then(res=>this.list=res as MovieDetail[]);
    }
    
    getListfull = async () => {
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
    
    getList = async (id) => {
        try {

            const result = await this.http.get(this.baseURL+'/'+id).toPromise();
            console.log(result)
            return result;
        }
        catch (e) {
            console.log(e);
            // this.removeToken();
        }
    }
    getListActorFromMovie= async(id)=>{
        try{
            const result=await this.http.get(this.URLActor+'/'+id).toPromise();
            console.log(result)
            return result
        }
        catch (e) {
            console.log(e);
            // this.removeToken();
        }

    }
    getListTypeFromMovie= async(id)=>{
        try{
            const result=await this.http.get(this.URLType+'/'+id).toPromise();
            console.log(result)
            return result
        }
        catch (e) {
            console.log(e);
            // this.removeToken();
        }

    }
}