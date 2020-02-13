using MyEvernote.BusinessLayer;
using MyEvernote.Entities;
using MyEvernote.Entities.Messages;
using MyEvernote.Entities.ValueObjects;
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
            if (ModelState.IsValid)
            {
                EvernoteUserManager eum = new EvernoteUserManager();
                BusinessLayerResult<EvernoteUser> res = eum.LoginUser(model);

                if (res.Errors.Count > 0)
                {
                    res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));

                    if (res.Errors.Find(x => x.Code == ErrorMessageCode.UserIsNotActive) != null)
                    {
                        ViewBag.SetLink = "http://Home/Activate/1234-5667-1232";
                    }

                    return View(model);
                }

                Session["login"] = res.Result;//kullanıcı bilgisi saklama

                return RedirectToAction("Index");//yönlendirme
            }


            return View(model);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {

                EvernoteUserManager eum = new EvernoteUserManager();
                BusinessLayerResult<EvernoteUser> res = eum.RegisterUser(model);
                if (res.Errors.Count > 0)
                {
                    res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));

                    return View(model);
                }

                return RedirectToAction("RegisterOk");
                
            }


            return View(model);
        }   

        public ActionResult Logout()
        {
            Session.Clear();

            return RedirectToAction("Index");
        }

        public ActionResult RegisterOk()
        {
            return View();
        }

        public ActionResult UserActive(Guid id)
        {
            //TODO: siteyi yayına aldıktan sonra domain adı ile mail üretip app settings ayarları değiştir ve mailin gelip gelmediğini tekrar kontrol et.

            EvernoteUserManager eum = new EvernoteUserManager();
            BusinessLayerResult<EvernoteUser> res = eum.ActivateUser(id);

            if (res.Errors.Count > 0)
            {
                TempData["errors"] = res.Errors;
                return RedirectToAction("UserActivateCancel");
            }

            return RedirectToAction("UserActivateOk");
        }

        public ActionResult UserActivateOk()
        {
            return View();
        }

        public ActionResult UserActivateCancel()
        {
            List<ErrorMessageObj> errors = null;

            if (TempData["error"] != null)
            {
                errors = TempData["error"] as List<ErrorMessageObj>;
            } 
            return View(errors);
        }

    }
}
