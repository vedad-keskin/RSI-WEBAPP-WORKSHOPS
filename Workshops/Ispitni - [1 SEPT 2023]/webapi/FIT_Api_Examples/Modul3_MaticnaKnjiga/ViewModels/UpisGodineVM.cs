using FIT_Api_Examples.Modul0_Autentifikacija.Models;
using FIT_Api_Examples.Modul2.Models;
using FIT_Api_Examples.Modul3_MaticnaKnjiga.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace FIT_Api_Examples.Modul3_MaticnaKnjiga.ViewModels
{
    public class UpisGodineVM
    {
        public DateTime datumUpisa { get; set; }
        public int godinaStudija { get; set; }
 
        public int akademskaGodinaid { get; set; }

        public float cijenaSkolarine { get; set; }
        public bool obnova { get; set; }

        public int studentid { get; set; }

        public int? evidentiraoid { get; set; }
    }
}
