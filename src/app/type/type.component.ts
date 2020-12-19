import { Component, OnInit } from "@angular/core";
import { NgForm } from "@angular/forms";
import { IdType } from "../services/profile";
import { Type } from "../type/share/type.model";
import { TypeService } from "../type/share/type.service";
export class TypeDetail implements OnInit{
    public Type1:Type
    constructor(private service:TypeService){}
    ngOnInit(){
        IdType.id=""
        this.getPath();
    }
    resetForm(form:NgForm)
    {
      form.form.reset();
      this.service.formData=new Type();
    }
    async getPath(){
        this.Type1 = new Type()
        const detail=await this.service.getList(IdType.id) as any
        this.Type1.typeId=detail["TypeId"]
        this.Type1.type_name=detail["Type_Name"]

    }
}