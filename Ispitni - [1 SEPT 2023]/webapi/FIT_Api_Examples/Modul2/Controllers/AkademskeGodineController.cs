using System.Collections.Generic;
using System.Linq;
using FIT_Api_Examples.Data;
using FIT_Api_Examples.Helper;
using Microsoft.AspNetCore.Mvc;

namespace FIT_Api_Examples.Modul2.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class AkademskeGodineController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public AkademskeGodineController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet]
        public List<CmbStavke> GetAll_ForCmb()
        {
            return _dbContext.AkademskaGodina
                .OrderByDescending(x => x.id)
                .Select(s=>new CmbStavke
                {
                    opis = s.opis,
                    id = s.id
                })
                .ToList();
        }
 
    }
}
