using fs.Models;
using fs.ViewModels;
using Microsoft.AspNet.Identity;
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
        
        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new GigFormViewModel
            {
                Genres = db.Genres.ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(GigFormViewModel viewModel)
        {
            var gig = new Gig
            {
                ArtistId = User.Identity.GetUserId(),
                DateTime = viewModel.DateTime,
                GenreId = viewModel.Genre,
                Venue = viewModel.Venue
            };

            db.Gigs.Add(gig);
            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}