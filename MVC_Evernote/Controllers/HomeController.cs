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

            return View(nm.GetNotes());
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


            return View("Index", cat.Notes);
        }
    }
}
