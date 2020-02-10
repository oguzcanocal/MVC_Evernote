using MyEvernote.BusinessLayer;
using MyEvernote.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Evernote.Controllers
{
    public class CategoryController : Controller
    {
        //**TempData ile notları gönderme**
        //public ActionResult Select(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
        //    }

        //    CategoriesManager cm = new CategoriesManager();
        //    Category cat = cm.GetCategoryId(id.Value);

        //    if (cat == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    TempData["model"] = cat.Notes;

        //    return RedirectToAction("Index", "Home");
        //}
    }
}