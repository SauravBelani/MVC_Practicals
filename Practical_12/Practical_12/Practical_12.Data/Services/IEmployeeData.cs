using Practical_12.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_12.Data.Services
{
    public interface IEmployeeData
    {
        IEnumerable<Employee> GetAll();
        Employee Get(int id);
        void Add(Employee employee);
        void Update(Employee employee);
        void Delete(int id);
    }
}
