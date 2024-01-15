import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {MojConfig} from "../moj-config";
import {HttpClient} from "@angular/common/http";
import {AutentifikacijaHelper} from "../_helpers/autentifikacija-helper";

declare function porukaSuccess(a: string):any;
declare function porukaError(a: string):any;

@Component({
  selector: 'app-student-maticnaknjiga',
  templateUrl: './student-maticnaknjiga.component.html',
  styleUrls: ['./student-maticnaknjiga.component.css']
})
export class StudentMaticnaknjigaComponent implements OnInit {

  constructor(private httpKlijent: HttpClient, private route: ActivatedRoute) {
    this.route.params.subscribe(params=>{
      this.studentID=<number>params['id'];
    })
  }

  studentID:any;
  novi_upis:any;
  student:any;
  akademskegodine:any;
  upisi: any;
  ovjera_upis:any;

  ovjeriLjetni(s:any) {

  }

  upisLjetni(s:any) {

  }

  ovjeriZimski(s:any) {

  }

  ngOnInit(): void {
    this.GetStudent();
    this.GetAkademskeGodine();
    this.fetchUpisi();
  }

  private GetStudent() {
    this.httpKlijent.get(MojConfig.adresa_servera + '/GetStudent' , {
      params:{studentid : this.studentID},
      observe:'response'
    }).subscribe(response=>{
      if(response.status == 200){
        this.student = response.body;
      }

    } )
  }

  private GetAkademskeGodine() {
    this.httpKlijent.get(MojConfig.adresa_servera+ "/GetAllAkademskeGodine", MojConfig.http_opcije()).subscribe(x=>{
      this.akademskegodine = x;
    });
  }

  NoviUpis() {
    this.novi_upis={
      datumUpisa:new Date(),
      godinaStudija:0,
      akademskaGodinaid:1,
      cijenaSkolarine:100,
      obnova:false,
      studentid:this.studentID,
      evidentiraoid: AutentifikacijaHelper.getLoginInfo().autentifikacijaToken.korisnickiNalogId
    }
  }

  SpasiUpis() {
     this.httpKlijent.post(MojConfig.adresa_servera + '/DodajUpis', this.novi_upis, MojConfig.http_opcije()).subscribe(x=>{

       porukaSuccess("Upis dodan");
       this.ngOnInit();
       this.novi_upis = null;
    },error => {
       porukaError("Godinu mozete dodati samo ako je obnova");
     })
  }

  private fetchUpisi() {
    this.httpKlijent.get(MojConfig.adresa_servera + '/GetUpise',{
      params:{studentid:this.studentID},
      observe:'response'
    }).subscribe(response=>{
      this.upisi = response.body;
    })
  }

  OvjeriUpis() {

    this.httpKlijent.post(MojConfig.adresa_servera + '/DodajOvjeru', this.ovjera_upis, MojConfig.http_opcije()).subscribe(x=>{
      porukaSuccess("Upis ovjeren");
      this.ngOnInit();
      this.ovjera_upis = null;
    },error => {
      porukaError("Upis nije ovjeren");
    })

  }
}
