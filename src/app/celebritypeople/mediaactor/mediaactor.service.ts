import { MediaActor } from "./mediaactor.model";
import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
@Injectable({
    providedIn:'root'
})
export class MediaService{
    formData: MediaActor=new MediaActor(); // Khai bao doi tuong 
    private baseURL='/api/MediaActor/GetListMediaActorById';
    list:MediaActor[];
    constructor(private http:HttpClient){}
    postActorDetail(){
        return this.http.post(this.baseURL,this.formData);
    }
    putActorDetail(){
        return this.http.put(`${this.baseURL}/${this.formData.MediaId}`,this.formData);
    }
    deleteActorDetail(id:string)
    {
        return this.http.delete(`${this.baseURL}/${id}`);
    }
    refreshList(){
        this.http.get(this.baseURL)
        .toPromise()
        .then(res=>this.list=res as MediaActor[]);
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