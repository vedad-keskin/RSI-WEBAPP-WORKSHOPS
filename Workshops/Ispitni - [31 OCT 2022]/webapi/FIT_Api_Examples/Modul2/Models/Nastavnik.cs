using System.ComponentModel.DataAnnotations.Schema;
using FIT_Api_Examples.Modul0_Autentifikacija.Models;

namespace FIT_Api_Examples.Modul2.Models
{
    [Table("Nastavnik")]
    public class Nastavnik:KorisnickiNalog
    {
        public string ime { get; set; }
        public string prezime{ get; set; }
     
    }
}
