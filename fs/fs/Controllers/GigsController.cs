using fs.Models;
using fs.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace fs.Controllers
{
    public class GigsController : Controller
    {
        private ApplicationDbContext db;

        public GigsController()
        {
            db = new ApplicationDbContext();
        }
        // GET: Gigs
        public ActionResult Create()
        {
            var viewModel = new GigFormViewModel
            {
                Genres = db.Genres.ToList()
            };
            return View(viewModel);
        }
    }
}