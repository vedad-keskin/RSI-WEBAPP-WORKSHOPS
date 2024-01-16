using FIT_Api_Examples.Data;
using FIT_Api_Examples.Modul2.ViewModels;
using FIT_Api_Examples.Modul3_MaticnaKnjiga.Models;
using FIT_Api_Examples.Modul3_MaticnaKnjiga.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FIT_Api_Examples.Modul3_MaticnaKnjiga.Kontroleri
{ 
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class UpisGodinaController : ControllerBase
    {

        private readonly ApplicationDbContext _dbContext;

        public UpisGodinaController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }


        [HttpGet]
        [Route("/GetUpisi")]
        public ActionResult<List<UpisGodina>> GetUpiseStudenta([FromQuery] int studentid)
        {
            var upisi = _dbContext.UpisGodina.Include("evidentirao").Include("student").Include("akademskaGodina").Where(x => x.studentid == studentid).ToList();



            return Ok(upisi);
        }

        [HttpPost]
        [Route("/DodajUpis")]
        public ActionResult DodajStudenta([FromBody] UpisGodinaVM x)
        {
            //if (!HttpContext.GetLoginInfo().isLogiran)
            //    return BadRequest("nije logiran");

            if(_dbContext.UpisGodina.ToList().Exists(u => u.studentid == x.studentid && u.godinaStudija == x.godinaStudija))
            {
                if (x.obnova)
                {
                    var noviUpis = new UpisGodina()
                    {
                        akademskaGodinaid = x.akademskaGodinaid,
                        datumUpis = x.datumUpis,
                        cijenaSkolarine = x.cijenaSkolarine,
                        evidentiraoid = x.evidentiraoid,
                        obnova = x.obnova,
                        studentid = x.studentid,
                        godinaStudija = x.godinaStudija

                    };
                    _dbContext.UpisGodina.Add(noviUpis);
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
                var noviUpis = new UpisGodina()
                {
                    akademskaGodinaid = x.akademskaGodinaid,
                    datumUpis = x.datumUpis,
                    cijenaSkolarine = x.cijenaSkolarine,
                    evidentiraoid = x.evidentiraoid,
                    obnova = x.obnova,
                    studentid = x.studentid,
                    godinaStudija = x.godinaStudija

                };
                _dbContext.UpisGodina.Add(noviUpis);
                _dbContext.SaveChanges();
                return Ok();
            }


        
        }

        [HttpPost]
        [Route("/OvjeriUpis")]
        public ActionResult DodajStudenta([FromBody] OvjeraGodinaVM x)
        {
            //if (!HttpContext.GetLoginInfo().isLogiran)
            //    return BadRequest("nije logiran");

            var ovjera = _dbContext.UpisGodina.Where(u => u.id == x.id).First();


            ovjera.napomena = x.napomena;
            ovjera.datumOvjera = x.datumOvjera;


          
           _dbContext.SaveChanges();
           return Ok();


        }

    }
}
