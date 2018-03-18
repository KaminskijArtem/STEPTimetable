using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestBCSETimeTableProj.DBDAO;

namespace TestBCSETimeTableProj.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            using (var context = new TestBCSETimeTableProjContext())
            {
                var s = context.Groups.Where(x => x.IdGroup == 5).ToList();
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}