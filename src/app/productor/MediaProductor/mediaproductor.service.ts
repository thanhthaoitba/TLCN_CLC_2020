import { MediaProductor } from "../MediaProductor/mediaproductor.model";
import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
@Injectable({
    providedIn:'root'
})
export class MediaService{
    formData: MediaProductor=new MediaProductor(); // Khai bao doi tuong 
    private baseURL='/api/MediaProductor/GetListMediaProductorByProductorId';
    list:MediaProductor[];
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
        .then(res=>this.list=res as MediaProductor[]);
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