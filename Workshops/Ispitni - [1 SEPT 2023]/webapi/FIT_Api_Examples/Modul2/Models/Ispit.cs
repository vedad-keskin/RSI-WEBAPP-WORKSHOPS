using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Examples.Modul2.Models
{
    public class Ispit
    {
        public int ID { get; set; }
        public string Naziv { get; set; }
        
        [ForeignKey(nameof(PredmetID))] 
        public Predmet predmet { get; set; }
        public int PredmetID { get; set; }
        
        public DateTime DatumIspita { get; set; }

    }
}
