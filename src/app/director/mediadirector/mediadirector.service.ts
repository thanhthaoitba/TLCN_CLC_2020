import {DirectorPhoto} from"../photodirector/photodirector.model"
import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
@Injectable({
    providedIn:'root'
})
export class MediaDirectorService{
    // formData: PhotoActor=new PhotoActor(); // Khai bao doi tuong 
     private baseURL='/api/MediaDirector/GetlistMediaDirectorById';
     list:DirectorPhoto[];
     constructor(private http:HttpClient){}
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