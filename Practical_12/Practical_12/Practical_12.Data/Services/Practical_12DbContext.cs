using Practical_12.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_12.Data.Services
{
    public class Practical_12DbContext:DbContext
    {
        public DbSet<Employee> Employees { get; set; }
    }
}
