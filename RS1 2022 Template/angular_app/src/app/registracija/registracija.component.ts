import { Component, OnInit } from '@angular/core';
import {MojConfig} from "../moj-config";

@Component({
  selector: 'app-registracija',
  templateUrl: './registracija.component.html',
  styleUrls: ['./registracija.component.css']
})
export class RegistracijaComponent implements OnInit {
  swagger_adresa: string=MojConfig.adresa_servera+"/swagger";

  constructor() { }

  ngOnInit(): void {
  }

}
