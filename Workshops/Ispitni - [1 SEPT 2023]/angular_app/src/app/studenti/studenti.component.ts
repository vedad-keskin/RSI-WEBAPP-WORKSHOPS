import { Component, OnInit } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {MojConfig} from "../moj-config";
import {Router} from "@angular/router";
import {AutorizacijaLoginProvjera} from "../_guards/autorizacija-login-provjera.service";
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
  opstine:any;
  novi_student:any;
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
    if(!this.filter_ime_prezime && !this.filter_opstina){
      return this.studentPodaci;
    }

    return this.studentPodaci.filter((x:any)=> (!this.filter_ime_prezime || (x.ime + ' ' + x.prezime).toLowerCase().startsWith(this.ime_prezime.toLowerCase()) || (x.prezime + ' ' + x.ime).toLowerCase().startsWith(this.ime_prezime.toLowerCase()) )
    && (!this.filter_opstina || x.opstina_rodjenja.description.toLowerCase().startsWith(this.opstina.toLowerCase())))

  }

  private fetchOpstine() {
    this.httpKlijent.get(MojConfig.adresa_servera+ "/GetAllOpstine", MojConfig.http_opcije()).subscribe(x=>{
      this.opstine = x;
    });
  }

  NoviStudent() {
    this.novi_student = {
      ime: this.ime_prezime,
      prezime:'',
      opstina_rodjenja_id:this.opstine.length,
    }
  }

  SpasiStudenta() {
    this.httpKlijent.post(MojConfig.adresa_servera + '/DodajStudenta', this.novi_student, MojConfig.http_opcije()).subscribe(x=>{

      porukaSuccess("Student dodan");
      this.novi_student = null;
      this.ngOnInit()
    },error => {
      porukaError("Student nije dodan");
      }
      );
  }

  EditujStudenta() {



    this.httpKlijent.post(MojConfig.adresa_servera + '/DodajStudenta', this.edit_student, MojConfig.http_opcije()).subscribe(x=>{

        porukaSuccess("Student editovan");
        this.edit_student = null;
        this.ngOnInit()
      },error => {
        porukaError("Student nije editovan");
      }
    );
  }


  Obrisi(id:any) {
    this.httpKlijent.post(MojConfig.adresa_servera + '/ObrisiStudenta', id, MojConfig.http_opcije()).subscribe(x=>{

        porukaSuccess("Student obrisan");
        this.ngOnInit()
      },error => {
        porukaError("Student nije obrisan");
      }
    );
  }
}
