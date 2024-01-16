import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {MojConfig} from "../moj-config";
import {HttpClient} from "@angular/common/http";
import {parseArguments} from "@angular/cli/models/parser";
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
  upisi:any;
  akademskeGodine:any;
  ovjera_upis:any;
  ovjeriLjetni(s:any) {

  }

  upisLjetni(s:any) {

  }

  ovjeriZimski(s:any) {

  }

  ngOnInit(): void {
    this.GetStudent();
    this.fetchUpisi();
    this.fetchAkademskeGodine();
  }

  NoviUpis() {
    this.novi_upis={
      evidentiraoid: AutentifikacijaHelper.getLoginInfo().autentifikacijaToken.korisnickiNalogId,
      studentid:this.studentID

    }
  }

  private GetStudent() {
    this.httpKlijent.get(MojConfig.adresa_servera + '/GetStudent',{
      headers:{
        'autentifikacija-token':AutentifikacijaHelper.getLoginInfo().autentifikacijaToken.vrijednost
      },
      params:{studentid:this.studentID},
      observe:'response',

    }).subscribe(response=>{
      if(response.status == 200){
        this.student = response.body;
      }
    })
  }

  private fetchUpisi() {
    this.httpKlijent.get(MojConfig.adresa_servera+ '/GetUpisi'  ,{
      headers:{
        'autentifikacija-token': AutentifikacijaHelper.getLoginInfo().autentifikacijaToken.vrijednost
      },
      params:{studentid:this.studentID},
      observe:'response'
    }).subscribe(response=>{
      this.upisi = response.body;


    },error => {

      porukaError("Godine nisu ucitane");
    })
  }

  private fetchAkademskeGodine() {
    this.httpKlijent.get(MojConfig.adresa_servera+'/GetAllAkademskeGodine',MojConfig.http_opcije()).subscribe(x=>{
      this.akademskeGodine = x;
    })
  }

  SpasiSemestar() {
    this.httpKlijent.post(MojConfig.adresa_servera + '/DodajUpis', this.novi_upis,MojConfig.http_opcije()).subscribe(x=>{

      porukaSuccess("Semestar dodan");
      this.novi_upis = null;
      this.ngOnInit();
    },error => {
      porukaError("Semstar nije dodan jer je godina vec upisana na nije obnova");
    })
  }

  OvjeriSemestar() {
    this.httpKlijent.post(MojConfig.adresa_servera+ '/OvjeriUpis', this.ovjera_upis, MojConfig.http_opcije()).subscribe(x=>{

      porukaSuccess("Semestar ovjeren");
      this.ovjera_upis = null;
      this.ngOnInit();
    },error => {
      porukaError("Semstar nije ovjeren");

    })
  }
}
