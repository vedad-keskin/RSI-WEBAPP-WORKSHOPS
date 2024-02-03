using System.ComponentModel.DataAnnotations;

namespace FIT_Api_Examples.Modul2.Models
{
    public class Drzava
    { 
        [Key]
        public int id { get; set; }
        public string naziv { get; set; }
    }
}
