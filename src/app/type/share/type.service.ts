import { Type } from "./type.model";
import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
@Injectable({
    providedIn:'root',
})
export class TypeService{
    formData: Type=new Type();
    private baseURL='/api/Type';
    list:Type[];
    constructor(private http:HttpClient){}
    postTypeDetail(){
        return this.http.post(this.baseURL,this.formData);

    }
    putTypeDetail(){
        return this.http.put(`${this.baseURL}/${this.formData.typeId}`,this.formData);
    }
    deleteTypeDetail(id: string)
    {
        return this.http.delete(`${this.baseURL}/${id}`);
    }
    refreshList(){
        this.http.get(this.baseURL)
        .toPromise()
        .then(res=>this.list=res as Type[]);
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