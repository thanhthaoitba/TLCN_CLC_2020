import { Productor } from "./productor.model";
import { Injectable } from "@angular/core";
import {HttpClient  } from "@angular/common/http";
@Injectable({
    providedIn:'root',
})
export class ProductorService{
    formData: Productor=new Productor();
    private baseURL='api/Productor';
    list:Productor[];
    constructor(private http:HttpClient){

    }
    postProductorDetail(){
        return this.http.post(this.baseURL,this.formData)
    }
    putProductorDetail(){
        return this.http.put(`${this.baseURL}/${this.formData.productorId}`,this.formData);
    }
    deleteProductorDetail(id: string)
    {
        return this.http.delete(`${this.baseURL}/${id}`);
    }
    refreshList(){
        this.http.get(this.baseURL)
        .toPromise()
        .then(res=>this.list=res as Productor[]);
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