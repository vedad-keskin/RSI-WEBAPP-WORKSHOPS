import { Component, OnInit } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {MojConfig} from "../moj-config";
import {Router} from "@angular/router";
declare function porukaSuccess(a: string):any;
declare function porukaError(a: string):any;

@Component({
  selector: 'app-studenti',
  templateUrl: './studenti.component.html',
  styleUrls: ['./studenti.component.css']
})
export class StudentiComponent implements OnInit {

  title:string = 'angularFIT2';
  ime_prezime:string = '';
  opstina: string = '';
  studentPodaci: any;
  filter_ime_prezime: boolean;
  filter_opstina: boolean;
  novi_student:any;
  opstine:any;
  edit_student:any;

  constructor(private httpKlijent: HttpClient, private router: Router) {
  }

  testirajWebApi() :void
  {
    this.httpKlijent.get(MojConfig.adresa_servera+ "/Student/GetAll", MojConfig.http_opcije()).subscribe(x=>{
      this.studentPodaci = x;
    });
  }

  ngOnInit(): void {
    this.testirajWebApi();
    this.fetchOpstine();
  }

  FiltrirajStudente() {
    if(this.ime_prezime == "" && this.opstina==""){
      return this.studentPodaci;
    }

    return this.studentPodaci.filter((x:any)=>
      (
        !this.filter_ime_prezime || (x.ime + ' '+ x.prezime).toLowerCase().startsWith(this.ime_prezime.toLowerCase()) || (x.prezime + ' '+ x.ime).toLowerCase().startsWith(this.ime_prezime.toLowerCase())
      )
       &&
      (
        !this.filter_opstina || x.opstina_rodjenja.description.toLowerCase().startsWith(this.opstina.toLowerCase())
      )
    )

  }

  NoviStudent() {
    this.novi_student={
      ime: this.ime_prezime.charAt(0).toUpperCase() + this.ime_prezime.slice(1),
      prezime:"",
      opstina_rodjenja_id:2
    }
  }

  SpasiStudenta() {
     this.httpKlijent.post(MojConfig.adresa_servera + '/DodajStudenta',this.novi_student,MojConfig.http_opcije()).subscribe(x=>{
       this.novi_student = null;
       this.ngOnInit();
       porukaSuccess("Student dodan");
     },error => {
       porukaError("Student nije dodan");
     })
  }

  private fetchOpstine() {
    this.httpKlijent.get(MojConfig.adresa_servera+ '/GetOpstine', MojConfig.http_opcije()).subscribe(x=>{
      this.opstine = x;
    })
  }

  EditujStudenta() {
    this.httpKlijent.post(MojConfig.adresa_servera+ '/DodajStudenta',this.edit_student,MojConfig.http_opcije()).subscribe(x=>{
      this.edit_student = null;
      porukaSuccess("Editovan student");
      this.ngOnInit();

    },error => {
      porukaError("Student nije editovan");
    })
  }

  Obrisi(id:any) {
    this.httpKlijent.post(MojConfig.adresa_servera + '/ObrisiStudenta', id,MojConfig.http_opcije()).subscribe(x=>{

      porukaSuccess("Editovan student");
      this.ngOnInit();
    },error => {
      porukaError("Student nije obrisan");

    })
  }
}
