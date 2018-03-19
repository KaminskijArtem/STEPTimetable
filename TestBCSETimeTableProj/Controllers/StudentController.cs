using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestBCSETimeTableProj.DBDAO;
using TestBCSETimeTableProj.Models;

namespace TestBCSETimeTableProj.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            using (var _context = new TestBCSETimeTableProjContext())
            {
                var groups = (from p in _context.Groups
                              orderby p.IdGroup
                              select new GroupViewModel { IdGroup = p.IdGroup, NameGroup = p.NameGroup }).ToList();

                return View(groups);
            }
            
        }

        public ActionResult DetailsWeek(int idgroup, int subgroup)
        {
            return View();
        }

        public int GetCurrentWeek()
        {
            var dtNow = new DateTime();
            dtNow = DateTime.Now;
            int year;


            if (dtNow.Month < 9)
                year = dtNow.Year - 1;
            else
                year = dtNow.Year;

            var dtSept = new DateTime(year, 9, 1);

            var diff = dtNow - dtSept;
            int differenceInDays = diff.Days;
            differenceInDays += (int)dtSept.DayOfWeek - 1;
            int currentWeek = 1 + (differenceInDays % 28) / 7;
            return currentWeek;
        }
    }
}