using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WindowsAuthentication.Controllers
{
    public class HomeController : Controller
    {
        [Authorize(Users = @"SF-CPU-251\saurav")]
        public ActionResult Index()
        {
            return View();
        }
  
        [Authorize(Users = @"SF-CPU-251\Simfromsolutions")]
        public ActionResult Simfromsolutions()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}