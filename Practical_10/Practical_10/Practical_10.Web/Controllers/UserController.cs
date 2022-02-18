using Practical_10.Data.Models;
using Practical_10.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practical_10.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserData list;

        public UserController(IUserData list)
        {
            this.list = list;
        }
        // GET: User
        public ActionResult Index()
        {
            var model = list.GetAll();
            return View(model);
        }
        public ActionResult Details(int id)
        {
            var model = list.Get(id);
            if (model == null)
                return View("NotFound");
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                list.Add(user);
                return RedirectToAction("Details", new { id = user.Id });
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = list.Get(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                list.Update(user);
                return RedirectToAction("Details", new { id = user.Id });
            }
            return View(user);
        }
        public ActionResult Delete(int id)
        {
            var model = list.Get(id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection form)
        {
            list.Delete(id);
            return RedirectToAction("Index");
        }
    }
}