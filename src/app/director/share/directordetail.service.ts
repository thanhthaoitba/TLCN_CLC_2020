import { Director } from "./directordetail.model";
import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { IdDirector } from "../../services/profile";
@Injectable({
    providedIn:'root'
})
export class DirectorService{
    formData:Director=new Director();
    private baseURL='/api/Director';
    list:Director[];
    constructor(private http:HttpClient){}
    postDirectorDetail(){
        return this.http.post(this.baseURL, this.formData);
    }
    putDirectorDetail(){
        return this.http.put(`${this.baseURL}/${this.formData.DirectorId}`,this.formData);

    }
    deleteDirectorDetail(id:string)
    {
        return this.http.delete(`${this.baseURL}/${id}`)
    }
    refreshList(){
        this.http.get(this.baseURL)
        .toPromise()
        .then(res=>this.list=res as Director[]);
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
}