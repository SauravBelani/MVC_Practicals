using Practical_09.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practical_09.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = DateTime.Now.ToString();
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Search(string name)
        {
            var input = Server.HtmlEncode(name);
            return Content(input);
        }
        /// <summary>
        /// ContentResult return type is used for returning Content i.e. String, XML string, etc. from Controller to View.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ContentResult ContentResult(string name)
        {
            string currentDateTime = string.Format("Hello {0}.\nCurrent DateTime: {1}", name, DateTime.Now.ToString());
            return Content(currentDateTime);
        }
        /// <summary>
        /// The EmptyResult is a class in MVC which does not return anything at client site, its just like Void method .
        /// </summary>
        /// <returns></returns>
        public EmptyResult EmptyData()
        {
            return new EmptyResult();
        }
        [HttpGet]
        public JavaScriptResult WarningMessage()
        {
            var msg = "alert('Are you sure want to Continue?');";
            return new JavaScriptResult() { Script = msg };
        }
        public FileContentResult DownloadContent()
        {
            var myfile = System.IO.File.ReadAllBytes(@"C:\Users\saurav\source\repos\MVC_practical\Practical_09\Practical_09\Practical_09\Hello.txt");
            return new FileContentResult(myfile, "application/txt");
        }
        public JsonResult jsonResult()
        {
            Employee emp = new Employee()
            {
                ID = "01",
                Name = "Saurav",
                Mobile = "9265866744"
            };
            return Json(emp, JsonRequestBehavior.AllowGet);
        }
        [OutputCache(Duration = 3)]
        public ActionResult OutPutTest()
        {
            ViewBag.Date = DateTime.Now.ToString();
            return View();
        }
        public class MyExceptionFilter : FilterAttribute, IExceptionFilter
        {
            public void OnException(ExceptionContext filterContext)
            {
                if (!filterContext.ExceptionHandled)
                {
                    filterContext.Result = new ViewResult()
                    {
                        ViewName = "Error"
                    };
                }
                filterContext.ExceptionHandled = true;
            }
        }
        [MyExceptionFilter]
        public int Exception()
        {
            int a = 65;
            int b = 0;
            int c = a / b;
            return c;
        }
    }
}