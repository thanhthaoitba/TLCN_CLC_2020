import { User } from "./userprofile.model";
import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
@Injectable({
    providedIn:'root'
})
export class UserService{
    formData:User=new User();
    private baseURL='/api/User';
    list:User[];
    constructor(private http:HttpClient){}
    postDirectorDetail(){
        return this.http.post(this.baseURL, this.formData);
    }
    putDirectorDetail(){
        return this.http.put(`${this.baseURL}/${this.formData.userId}`,this.formData);

    }
    deleteDirectorDetail(id:string)
    {
        return this.http.delete(`${this.baseURL}/${id}`)
    }
    refreshList(){
        this.http.get(this.baseURL)
        .toPromise()
        .then(res=>this.list=res as User[]);
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