

export class LoginInformacije {
  autentifikacijaToken:        AutentifikacijaToken=null;
  isLogiran:                   boolean=false;
}

export interface AutentifikacijaToken {
  id:                   number;
  vrijednost:           string;
  korisnickiNalogId:    number;
  korisnickiNalog:      KorisnickiNalog;
  vrijemeEvidentiranja: Date;
  ipAdresa:             string;
}

export interface KorisnickiNalog {
  id:                 number;
  korisnickoIme:      string;
  slika_korisnika:    string;
  isNastavnik:        boolean;
  isStudent:          boolean;
  isAdmin:            boolean;
  isProdekan:         boolean;
  isDekan:            boolean;
  isStudentskaSluzba: boolean;
}
