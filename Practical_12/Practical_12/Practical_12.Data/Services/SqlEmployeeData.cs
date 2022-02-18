using Practical_12.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_12.Data.Services
{
    public class SqlEmployeeData : IEmployeeData
    {
        private readonly Practical_12DbContext db;

        public SqlEmployeeData(Practical_12DbContext db)
        {
            this.db = db;
        }
        public void Add(Employee employee)
        {
            db.Employees.Add(employee);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var emp = db.Employees.Find(id);
            db.Employees.Remove(emp);
            db.SaveChanges();
        }

        public Employee Get(int id)
        {
            return db.Employees.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Employee> GetAll()
        {
            return db.Employees.OrderBy(r => r.Name);
        }

        public void Update(Employee employee)
        {
            var entry = db.Entry(employee);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
