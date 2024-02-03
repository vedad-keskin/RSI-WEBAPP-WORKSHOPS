import {HttpHeaders} from "@angular/common/http";
import {AutentifikacijaHelper} from "./_helpers/autentifikacija-helper";
import {AutentifikacijaToken} from "./_helpers/login-informacije";

export class MojConfig{
  static adresa_servera = "http://localhost:5000";
  static http_opcije= function (){

    let autentifikacijaToken:AutentifikacijaToken = AutentifikacijaHelper.getLoginInfo().autentifikacijaToken;
    let mojtoken = "";

    if (autentifikacijaToken!=null)
      mojtoken = autentifikacijaToken.vrijednost;
    return {
        headers: {
        'autentifikacija-token': mojtoken,
      }
    };
  }

}
