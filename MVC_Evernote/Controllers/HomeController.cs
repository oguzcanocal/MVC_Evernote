using MVC_Evernote.ViewModels;
using MyEvernote.BusinessLayer;
using MyEvernote.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Evernote.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //**Kategori controllerından tempdata ile alma
            //if(TempData["model"] != null)
            //{
            //    return View(TempData["model"] as List<Note>);
            //}

            NoteManager nm = new NoteManager();

            return View(nm.GetNotes().OrderByDescending(x=>x.ModifiedOn).ToList());
            //return View(nm.GetNotesQueryable().OrderByDescending(x => x.ModifiedOn).ToList();
        }

        public ActionResult ByCategory(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            CategoriesManager cm = new CategoriesManager();
            Category cat = cm.GetCategoryId(id.Value);

            if (cat == null)
            {
                return HttpNotFound();
            }


            return View("Index", cat.Notes.OrderByDescending(x=>x.ModifiedOn).ToList());
        }

        public ActionResult MostLiked()
        {
            NoteManager nm = new NoteManager();

            return View("Index",nm.GetNotes().OrderByDescending(x=>x.LikeCount).ToList());
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            return View();
        }

        public ActionResult Logout()
        {
            return View();
        }

    }
}
