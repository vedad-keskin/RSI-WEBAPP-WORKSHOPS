using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FIT_Api_Examples.Modul0_Autentifikacija.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FIT_Api_Examples.Helper.AutentifikacijaAutorizacija
{
    public class AutorizacijaAttribute : TypeFilterAttribute
    {
        public AutorizacijaAttribute(bool studentskaSluzba, bool prodekan, bool dekan, bool admin, bool studenti, bool nastavnici)
            : base(typeof(MyAuthorizeImpl))
        {
            Arguments = new object[] {  };
        }
    }


    public class MyAuthorizeImpl : IActionFilter
    {
        private readonly bool _studentskaSluzba;
        private readonly bool _prodekan;
        private readonly bool _dekan;
        private readonly bool _admin;
        private readonly bool _studenti;
        private readonly bool _nastavnici;

        public MyAuthorizeImpl(bool studentskaSluzba, bool prodekan, bool dekan, bool admin, bool studenti, bool nastavnici)
        {
            _studentskaSluzba = studentskaSluzba;
            _prodekan = prodekan;
            _dekan = dekan;
            _admin = admin;
            _studenti = studenti;
            _nastavnici = nastavnici;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {


        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {

            if (filterContext.HttpContext.GetLoginInfo().isLogiran)
            {
                filterContext.Result = new UnauthorizedResult();
                return;
            }

            KretanjePoSistemu.Save(filterContext.HttpContext);
            
            if (filterContext.HttpContext.GetLoginInfo().isLogiran)
            {
                return;//ok - ima pravo pristupa
            }
           

            //else nema pravo pristupa
            filterContext.Result = new UnauthorizedResult();
        }
    }
}
