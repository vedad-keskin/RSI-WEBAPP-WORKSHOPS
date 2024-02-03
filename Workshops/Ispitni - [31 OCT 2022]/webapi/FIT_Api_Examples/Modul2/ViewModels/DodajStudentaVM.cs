using FIT_Api_Examples.Modul2.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace FIT_Api_Examples.Modul2.ViewModels
{
    public class DodajStudentaVM
    {
        public int id { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }

        public int? opstina_rodjenja_id { get; set; }

    }
}
