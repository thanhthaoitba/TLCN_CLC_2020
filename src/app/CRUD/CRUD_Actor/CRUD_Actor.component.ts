import {   Actor  } from "../../celebritypeople/shared/celebritypeople.model";
import { ActorService } from "../../celebritypeople/shared/celebritypeople.service";
import { Component,OnInit } from "@angular/core";
import {NgForm} from "@angular/forms"
@Component({
    selector: 'app-CRUD_Actor-form',
    templateUrl: './CRUD_Actor.component.html',
    styles: []
  })
  export class ActorDetailFormComponent implements OnInit{
      constructor(public service:ActorService){}
      ngOnInit():void{

      }
      resetForm(form: NgForm) {
        form.form.reset();
        this.service.formData = new Actor();
      }
      onSubmit(form:NgForm)
      {
        this.insertRecord(form)
      }
      insertRecord(form:NgForm)
      {
          this.service.postActor().subscribe(
              res=>{
                  this.resetForm(form);
                  this.service.refreshList();
              },
              err=>{console.log(err)}
          )
      }
  }