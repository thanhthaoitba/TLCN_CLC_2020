import { Actor } from "./celebritypeople.model";
import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
@Injectable({
    providedIn:'root'
})
export class ActorService{
    formData: Actor=new Actor(); // Khai bao doi tuong 
    private baseURL='/api/Actor/';
    list:Actor[];
    constructor(private http:HttpClient){}
    postActorDetail=async ()=>
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
    putActorDetail(){
        return this.http.put(`${this.baseURL}/${this.formData.ActorId}`,this.formData);
    }
    deleteActorDetail(id:string)
    {
        return this.http.delete(`${this.baseURL}/${id}`);
    }
    refreshList(){
        this.http.get(this.baseURL)
        .toPromise()
        .then(res=>this.list=res as Actor[]);
    }
    getList = async (id) => {
        try {

            const result = await this.http.get(this.baseURL+id).toPromise();
            console.log(result)
            return result;
        }
        catch (e) {
            console.log(e);
            // this.removeToken();
        }
    }
    
}