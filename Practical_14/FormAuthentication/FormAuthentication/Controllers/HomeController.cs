using FormAuthentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FormAuthentication.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login( TblUser model, string returnUrl)
        {
            using (DbUserEntities1 objContext = new DbUserEntities1())
            {
                var objUser = objContext.TblUsers.FirstOrDefault(x => x.Name == model.Name && x.Password == model.Password);
                if (objUser == null)
                {
                    ModelState.AddModelError("LogOnError", "The user name or password provided is incorrect.");
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(model.Name,true);

                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                       && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {

                        return RedirectToAction("Index");
                    }
                }
            }

            return View(model);
        }
        [Authorize]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}