import { PhotoActor } from "./photoactor.model";
import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
@Injectable({
    providedIn:'root'
})
export class PhotoActorService{
    formData: PhotoActor=new PhotoActor(); // Khai bao doi tuong 
    private baseURL='/api/PhotoActor/GetListPhotoActor';
    list:PhotoActor[];
    constructor(private http:HttpClient){}
    postActorDetail(){
        return this.http.post(this.baseURL,this.formData);
    }
    putActorDetail(){
        return this.http.put(`${this.baseURL}/${this.formData.PhotoActorId}`,this.formData);
    }
    deleteActorDetail(id:string)
    {
        return this.http.delete(`${this.baseURL}/${id}`);
    }
    refreshList(){
        this.http.get(this.baseURL)
        .toPromise()
        .then(res=>this.list=res as PhotoActor[]);
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