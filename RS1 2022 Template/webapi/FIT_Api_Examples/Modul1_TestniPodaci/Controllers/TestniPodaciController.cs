using System;
using System.Collections.Generic;
using System.Linq;
using FIT_Api_Examples.Data;
using FIT_Api_Examples.Helper;
using FIT_Api_Examples.Helper.AutentifikacijaAutorizacija;
using FIT_Api_Examples.Modul0_Autentifikacija.Models;
using FIT_Api_Examples.Modul0_Autentifikacija.ViewModels;
using FIT_Api_Examples.Modul2.Models;
using FIT_Api_Examples.Modul3_MaticnaKnjiga.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FIT_Api_Examples.Modul1_TestniPodaci.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class TestniPodaciController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public TestniPodaciController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet]
        public ActionResult Count()
        {
            Dictionary<string, int> data = new Dictionary<string, int>();
            data.Add("Nastavnik", _dbContext.Nastavnik.Count());
            data.Add("Student", _dbContext.Student.Count());
            data.Add("KorisnickiNalog", _dbContext.KorisnickiNalog.Count());
            data.Add("Opstina", _dbContext.Opstina.Count());
            data.Add("PrijavaIspita", _dbContext.PrijavaIspita.Count());
            data.Add("Predmet", _dbContext.Predmet.Count());
            data.Add("AkademskaGodina", _dbContext.AkademskaGodina.Count());
            data.Add("Drzava", _dbContext.Drzava.Count());

            return Ok(data);
        }

        [HttpPost]
        public ActionResult Generisi()
        {
            var drzave = new List<Drzava>();
            var opstine = new List<Opstina>();
            var predmeti = new List<Predmet>();
            var studenti = new List<Student>();
            var nastavnici = new List<Nastavnik>();
            var akademskeGodine = new List<AkademskaGodina>();

            akademskeGodine.Add(new AkademskaGodina { opis = "2019-20" });
            akademskeGodine.Add(new AkademskaGodina { opis = "2020-21" });
            akademskeGodine.Add(new AkademskaGodina { opis = "2021-22" });
            akademskeGodine.Add(new AkademskaGodina { opis = "2022-23" });

            drzave.Add(new Drzava { naziv = "BiH" });
            drzave.Add(new Drzava { naziv = "HR" });
            drzave.Add(new Drzava { naziv = "Njemacka" });                   
            drzave.Add(new Drzava { naziv = "Austrija" });
            drzave.Add(new Drzava { naziv = "SAD" });
            drzave.Add(new Drzava { naziv = "Malezija" });

            opstine.Add(new Opstina { description = "Sarajevo", drzava = drzave[0] });
            opstine.Add(new Opstina { description = "Mostar", drzava = drzave[0] });
            opstine.Add(new Opstina { description = "Zenica", drzava = drzave[0] });

            opstine.Add(new Opstina { description = "Split", drzava = drzave[1] });
            opstine.Add(new Opstina { description = "Zagreb", drzava = drzave[1] });

            opstine.Add(new Opstina { description = "Berlin", drzava = drzave[2] });
            opstine.Add(new Opstina { description = "Wiebaden", drzava = drzave[2] });

            opstine.Add(new Opstina { description = "Gratz", drzava = drzave[3] });
            opstine.Add(new Opstina { description = "Klagenfurt", drzava = drzave[3] });

            opstine.Add(new Opstina { description = "Boston", drzava = drzave[4] });
            opstine.Add(new Opstina { description = "New York", drzava = drzave[4] });

            opstine.Add(new Opstina { description = "Kuala Lumpur", drzava = drzave[5] });
            opstine.Add(new Opstina { description = "Subang Jaya", drzava = drzave[5] });

            predmeti.Add(new Predmet { ECTS = 5, Naziv = "Programiranje III", Sifra = "RS-PR3" });
            predmeti.Add(new Predmet { ECTS = 5, Naziv = "Razvoj softvera I", Sifra = "RS-RS1" });
            predmeti.Add(new Predmet { ECTS = 5, Naziv = "Razvoj softvera II", Sifra = "RS-RS2" });

            nastavnici.Add(new Nastavnik { ime = "Denis", prezime = "Music", korisnickoIme = "denis", lozinka = "test", slika_korisnika= Config.SlikeURL + "empty.png", });
            nastavnici.Add(new Nastavnik { ime = "Emina", prezime = "Junuz", korisnickoIme = "emina", lozinka = "test", slika_korisnika = Config.SlikeURL + "empty.png", });
            nastavnici.Add(new Nastavnik { ime = "Iris", prezime = "Memic-Fisic", korisnickoIme = "iris", lozinka = "test", slika_korisnika = Config.SlikeURL + "empty.png", isProdekan=true });
            nastavnici.Add(new Nastavnik { ime = "Nina", prezime = "Bijedic", korisnickoIme = "nina", lozinka = "test", slika_korisnika = Config.SlikeURL + "empty.png", isDekan = true });
            nastavnici.Add(new Nastavnik { ime = "Adil", prezime = "Joldic", korisnickoIme = "adil", lozinka = "test", slika_korisnika = Config.SlikeURL + "empty.png", isAdmin=true });


            Random rnd = new Random();

            for (int i = 0; i <100; i++)
            {
                studenti.Add(new Student
                {
                   broj_indeksa = $"IB200{i:d}",
                   created_time=DateTime.Now,
                   ime = TokenGenerator.GenerisiIme(5),
                   prezime = TokenGenerator.GenerisiIme(5),
                   korisnickoIme = TokenGenerator.GenerisiIme(5),
                   lozinka="test",
                   opstina_rodjenja=opstine.GetRandomElements(1)[0],
                   slika_korisnika = Config.SlikeURL + "empty.png"
                });
            }

            _dbContext.AddRange(nastavnici);
            _dbContext.AddRange(predmeti);
            _dbContext.AddRange(opstine);
            _dbContext.AddRange(drzave);
            _dbContext.AddRange(akademskeGodine);
            _dbContext.AddRange(studenti);
            _dbContext.SaveChanges();

            return Count();
        }
    }
}