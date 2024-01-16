using FIT_Api_Examples.Modul0_Autentifikacija.Models;
using FIT_Api_Examples.Modul2.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;

namespace FIT_Api_Examples.Modul3_MaticnaKnjiga.Models
{
    public class UpisGodina
    {
        [Key]
        public int id { get; set; }

        [ForeignKey(nameof(student))]
        public int studentid { get; set; }
        public Student student { get; set; }
        [ForeignKey(nameof(evidentirao))]
        public int evidentiraoid { get; set; }
        public KorisnickiNalog evidentirao { get; set; }

        [ForeignKey(nameof(akademskaGodina))]
        public int akademskaGodinaid { get; set; }
        public AkademskaGodina akademskaGodina { get; set; }

        public int godinaStudija { get; set; }
        public DateTime datumUpis { get; set; }
        public DateTime? datumOvjera { get; set; }
        public string? napomena { get; set; }
        public float cijenaSkolarine { get; set; }
        public bool obnova { get; set; }



    }
}
