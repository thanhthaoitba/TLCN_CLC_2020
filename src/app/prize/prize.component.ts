import { Component, OnInit} from '@angular/core';
import { Router } from '@angular/router';
import {NgForm  } from "@angular/forms";
import{IdPrize} from "./../services/profile"
import {Prize}from "./share/prize.model"
import {PrizeService} from "./share/prize.service"

export  class prizeDetail implements OnInit {
    public Prize:Prize
    constructor(private service:PrizeService){}
    ngOnInit(){
    IdPrize.Id="Pr01"
        this.getPath()
    }
    resetForm(form:NgForm)
    {
        form.form.reset();
        this.service.formData=new Prize();
    }
    async getPath(){
        this.Prize=new Prize()
        const name=await this.service.getList(IdPrize.Id)
        this.Prize.prizeId=name["prizeId"]
        this.Prize.prizeName=name["Prize_Name"]
    }
}