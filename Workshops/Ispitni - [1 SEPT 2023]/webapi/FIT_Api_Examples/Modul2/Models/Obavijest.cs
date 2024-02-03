using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FIT_Api_Examples.Modul0_Autentifikacija.Models;

namespace FIT_Api_Examples.Modul2.Models
{
    public class Obavijest
    {

        [Key]
        public int id {get;set;}
        public string naslov  {get;set;}
        public string tekst {get;set;}
        public DateTime datum_kreiranja { get; set; }

        [ForeignKey(nameof(evidentiraoKorisnik))]
        public int evidentiraoKorisnikID { get; set; }
        public KorisnickiNalog evidentiraoKorisnik { get; set; }


        [ForeignKey(nameof(izmijenioKorisnik))]
        public int? izmijenioKorisnikID { get; set; }
        public KorisnickiNalog izmijenioKorisnik { get; set; }
        
        
        public DateTime? datum_update  { get; set; }

    }
}
