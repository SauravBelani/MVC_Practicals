using Practical_12_2_.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_12_2_.Data.Services
{
    public interface IDesignationData
    {
        IEnumerable<Designation> GetAll();
        Designation Get(int id);
        void Add(Designation designation);
        void Update(Designation designation);
        void Delete(int id);
    }
}
