
import {Prize} from "./prize.model"
import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
@Injectable({
    providedIn:'root',
})
export class PrizeService{
    formData: Prize=new Prize();
    private baseURL='/api/Prize';
    list:Prize[];
    constructor(private http:HttpClient){}
    postPrizeDetail(){
        return this.http.post(this.baseURL,this.formData);

    }
    putPrizeDetail(){
        return this.http.put(`${this.baseURL}/${this.formData.prizeId}`,this.formData);
    }
    deletePrizeDetail(id: string)
    {
        return this.http.delete(`${this.baseURL}/${id}`);
    }
    refreshList(){
        this.http.get(this.baseURL)
        .toPromise()
        .then(res=>this.list=res as Prize[]);
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