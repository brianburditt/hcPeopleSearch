using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using hcPeopleSearch.Models;

namespace hcPeopleSearch.Controllers
{
    public class PersonController : Controller
    {
        private hcPeopleSearchEntities db = new hcPeopleSearchEntities();

        // GET: /Person/
        public ActionResult Index(string searchString)
        {
            var people = from p in db.people
                         select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                people = people.Where(s => s.first_name.Equals(searchString) || s.last_name.Equals(searchString));
            }

            return View(people); 
            //return View(await db.people.ToListAsync());
        }

        [HttpPost]
        public JsonResult Search(string searchString)
        {
            var people = from p in db.people
                         select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                people = people.Where(s => s.first_name.Equals(searchString) || s.last_name.Equals(searchString));
            }

            return Json(people, "json");
        }


        // GET: /Person/Soundex
        public async Task<ActionResult> Soundex()
        {
            return View(await db.people.ToListAsync());
        }

        // GET: /Person/Levenshtein
        public async Task<ActionResult> Levenshtein()
        {
            return View(await db.people.ToListAsync());
        }




    }
}
