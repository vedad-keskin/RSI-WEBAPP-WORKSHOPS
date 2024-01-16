using FIT_Api_Examples.Data;
using FIT_Api_Examples.Helper.AutentifikacijaAutorizacija;
using FIT_Api_Examples.Modul2.ViewModels;
using FIT_Api_Examples.Modul3_MaticnaKnjiga.Models;
using FIT_Api_Examples.Modul3_MaticnaKnjiga.ViewModels;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Internal.Account.Manage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FIT_Api_Examples.Modul3_MaticnaKnjiga.Kontroleri
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaticnaKnjigaController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public MaticnaKnjigaController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        [HttpGet]
        [Route("/GetUpise")]

        public ActionResult<List<UpisGodina>> GetUpiseStudenta([FromQuery] int studentid)
        {
            if (!HttpContext.GetLoginInfo().isLogiran)
                return BadRequest("nije logiran");

            var upisi = _dbContext.UpisGodina.Include("student").Include("evidentirao").Include("akademskaGodina").Where(x => x.studentid == studentid).ToList();


            return Ok(upisi);

        }
        [HttpPost]
        [Route("/DodajUpis")]

        public ActionResult DodajUpis([FromBody] UpisGodineVM x)
        {
            if (!HttpContext.GetLoginInfo().isLogiran)
                return BadRequest("nije logiran");

            if (_dbContext.UpisGodina.ToList().Exists(u => u.studentid == x.studentid && x.godinaStudija == u.godinaStudija))
            {
                if (x.obnova)
                {
                    var novaGodina = new UpisGodina()
                    {
                        studentid = x.studentid,
                        datumUpisa = x.datumUpisa,
                        akademskaGodinaid = x.akademskaGodinaid,
                        cijenaSkolarine = x.cijenaSkolarine,
                        godinaStudija = x.godinaStudija,
                        obnova = x.obnova,
                        evidentiraoid = x.evidentiraoid
                    };

                    _dbContext.UpisGodina.Add(novaGodina);

                    _dbContext.SaveChanges();

                    return Ok();
                }
                else
                {
                    return BadRequest();
                }



            }
            else
            {
                var novaGodina = new UpisGodina()
                {
                    studentid = x.studentid,
                    datumUpisa = x.datumUpisa,
                    akademskaGodinaid = x.akademskaGodinaid,
                    cijenaSkolarine = x.cijenaSkolarine,
                    godinaStudija = x.godinaStudija,
                    obnova = x.obnova,
                    evidentiraoid = x.evidentiraoid
                };

                _dbContext.UpisGodina.Add(novaGodina);

                _dbContext.SaveChanges();

                return Ok();
            }
        }

        [HttpPost]
        [Route("/DodajOvjeru")]

        public ActionResult DodajOvjeru([FromBody] OvjeraGodineVM x)
        {
            if (!HttpContext.GetLoginInfo().isLogiran)
                return BadRequest("nije logiran");

            var ovjera = _dbContext.UpisGodina.Where(u => u.id == x.id).First();


            ovjera.datumObnove = x.datumObnove;
            ovjera.napomena = x.napomena;

            _dbContext.SaveChanges();

            return Ok();
        }

    }
}
