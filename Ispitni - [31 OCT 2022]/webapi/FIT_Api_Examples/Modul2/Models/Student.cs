using System;
using System.ComponentModel.DataAnnotations.Schema;
using FIT_Api_Examples.Modul0_Autentifikacija.Models;
using FIT_Api_Examples.Modul2.Models;

namespace FIT_Api_Examples.Modul3_MaticnaKnjiga.Models
{
    [Table("Student")]
    public class Student:KorisnickiNalog
    {
        public string ime { get; set; }
        public string prezime{ get; set; }
        public string broj_indeksa { get; set; }
        [ForeignKey(nameof(opstina_rodjenja))]
        public int? opstina_rodjenja_id { get; set; }
        public Opstina opstina_rodjenja { get; set; }
        public DateTime created_time { get; set; }
  
    }
}
