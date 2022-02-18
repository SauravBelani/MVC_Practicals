using Practical_10.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practical_10.Web.Controllers
{
    public class HomeController : Controller
    {
        IUserData list;
        public HomeController()
        {
            list = new InMemoryUserData();
        }
        public ActionResult Index()
        {
            var model = list.GetAll();
            return View(model);
        }
    }
}