import { Component, OnInit} from '@angular/core';
import {NgForm  } from "@angular/forms";
import { Productor } from "../productor/share/productor.model";
import {  ProductorService} from "../productor/share/productor.service";
import { IdProductor, Profile } from "../services/profile";
@Component({
    selector: 'app-productor',
    templateUrl: './productor.component.html',
    styleUrls: ['./productor.component.css']
})
export class productorDetail implements OnInit{
    public productor:Productor
    constructor(private service:ProductorService){

    }
    ngOnInit(){
        IdProductor.Id="Pr01"
        this.getPath()
    }
    resetForm(form:NgForm)
    {
        form.form.reset();
        this.service.formData=new Productor();
    }
    async getPath()
    {
        this.productor=new Productor();
        const name=await this.service.getList(IdProductor.Id)
        this.productor.productorId=name["productorId"]
        this.productor.productorName=name["productor_Name"]
        this.productor.Year=name["year"]
        this.productor.name_manager=name["name_Manager"]
        this.productor.content_overview=name["content_overView"]
        this.productor.image=name["image"]
    }
}