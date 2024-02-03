using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FIT_Api_Examples.Modul2.ViewModels
{
    public class StudentUpdateVM
    {
        public string ime { get; set; }
        public string prezime { get; set; }
        public string broj_indeksa { get; set; }
        public DateTime? datum_rodjenja { get; set; }
        public int opstina_rodjenja_id { get; set; }
    }
}
