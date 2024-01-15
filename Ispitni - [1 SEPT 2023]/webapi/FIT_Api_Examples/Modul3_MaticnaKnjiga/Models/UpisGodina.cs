using FIT_Api_Examples.Modul0_Autentifikacija.Models;
using FIT_Api_Examples.Modul2.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Examples.Modul3_MaticnaKnjiga.Models
{
    public class UpisGodina
    {
        [Key]
        public int id { get; set; }
        public DateTime  datumUpisa { get; set; }
        public int godinaStudija { get; set; }

        [ForeignKey(nameof(akademskaGodinaid))]
        public int akademskaGodinaid { get; set; }
        public AkademskaGodina akademskaGodina { get; set; }
        public float cijenaSkolarine { get; set; }
        public bool obnova { get; set; }
        public DateTime? datumObnove { get; set; }
        public string? napomena { get; set; }

        [ForeignKey(nameof(studentid))]
        public int studentid { get; set; }
        public Student student { get; set; }

        [ForeignKey(nameof(evidentiraoid))]
        public int? evidentiraoid { get; set; }
        public KorisnickiNalog evidentirao { get; set; }


    }
}
