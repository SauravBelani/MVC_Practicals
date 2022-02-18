using Practical_12_2_.Data.App_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practical_12_2_.Web.Controllers
{
    public class DesignationController : Controller
    {
        DesignerLinqDataContext db = new DesignerLinqDataContext();
        // GET: Designation
        public ActionResult Index()
        {
            var desdata = from des in db.Designations select des;
            return View(desdata);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Designation designation)
        {
                db.Designations.InsertOnSubmit(designation);
                db.SubmitChanges();
                return RedirectToAction("index");
            
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = db.Designations.Single(r=>r.id == id);
            if (model == null)
                return HttpNotFound();
            return View(model);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = db.Designations.Single(r => r.id == id); 
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Designation designation)
        {
            var model = db.Designations.Single(r => r.id == designation.id);
            model.designation1 = designation.designation1;
            db.SubmitChanges();
            return View(designation);
        }
        public ActionResult Delete(int id)
        {
            var model = db.Designations.Single(r => r.id == id);
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
            var model = db.Designations.Single(r => r.id == id);
            db.Designations.DeleteOnSubmit(model);
            db.SubmitChanges();
            return RedirectToAction("Index");
        }
    }
}