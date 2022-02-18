using Newtonsoft.Json;
using Practical_12_2_.Data.App_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practical_12_2_.Web.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeLinqDataContext db = new EmployeeLinqDataContext();
        DesignerLinqDataContext db1 = new DesignerLinqDataContext();
        // GET: Designation
        public ActionResult Index()
        {
                List<Employee> employees = db.Employees.ToList();  
                List<Designation> designations = db1.Designations.ToList();
                var emp = from s in employees
                          join sa in designations on s.DesignationId equals sa.id
                      select new ViewModel
                      {
                          employees = s,
                          designations = sa
                      };
            return View(emp);
        }
        [HttpGet]
        public ActionResult Create()
        {
            var desdata = from des in db1.Designations select des;
            ViewBag.deslist = new SelectList(db1.Designations, "id", "designation1");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            db.Employees.InsertOnSubmit(employee);
            db.SubmitChanges();
            return RedirectToAction("index");

        }
        [HttpGet]
        public ActionResult CountRecords()
        {
            //var QSCount = (from s in db.Employees
            //               join sa in db1.Designations on s.DesignationId equals sa.id
            //               select s).GroupBy(r=>r.DesignationId).Count();
            List<Employee> employees = db.Employees.ToList();
            List<Designation> designations = db1.Designations.ToList();
            var QSCount = from des in designations
                           join emp in employees on des.id equals emp.DesignationId
                           group des by des.designation1 into data
                           select new CountEmp
                           {
                               Designation = data.Max(r=>r.designation1),
                               Count = data.Count(),
                           };
            //TempData["Count"] = QSCount;
            string json = JsonConvert.SerializeObject(QSCount);
            List<CountEmp> countEmps = JsonConvert.DeserializeObject<List<CountEmp>>(json);
            return View(countEmps);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = db.Employees.Single(r => r.Id == id);
            if (model == null)
                return HttpNotFound();
            return View(model);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var desdata = from des in db1.Designations select des;
            ViewBag.deslist = new SelectList(db1.Designations, "id", "designation1");
            var model = db.Employees.Single(r => r.Id == id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee employee)
        {
            var model = db.Employees.Single(r => r.Id == employee.Id);
            model.FirstName = employee.FirstName;
            model.LastName = employee.LastName;
            model.MiddleName = employee.MiddleName;
            model.DOB = employee.DOB;
            model.MobileNumber = employee.MobileNumber;
            model.Address = employee.Address;
            model.Salary = employee.Salary;

            db.SubmitChanges();
            return View(employee);
        }
        public ActionResult Delete(int id)
        {
            var model = db.Employees.Single(r => r.Id == id);
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
            var model = db.Employees.Single(r => r.Id == id);
            db.Employees.DeleteOnSubmit(model);
            db.SubmitChanges();
            return RedirectToAction("Index");
        }
    }
}