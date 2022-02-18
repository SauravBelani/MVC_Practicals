using Practical_10.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_10.Data.Services
{
    public class InMemoryUserData : IUserData
    {
        List<User> Users;
        public InMemoryUserData()
        {
            Users = new List<User>()
            {
                new User{Id=1,Name="Saurav Belani",DateOfBorth="05-03-2000",Address="Khambhat"}
            };
        }
        public void Add(User user)
        {
            Users.Add(user);
            user.Id = Users.Max(r => r.Id) + 1;
        }

        public void Delete(int id)
        {
            var user = Get(id);
            if(user != null)
            {
                Users.Remove(user);
            }
        }

        public User Get(int id)
        {
            return Users.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            return Users;
        }

        public void Update(User user)
        {
            var existing = Get(user.Id);
            if (existing != null)
            {
                existing.Name = user.Name;
                existing.DateOfBorth = user.DateOfBorth;
                existing.Address = user.Address;
            }
        }
    }
}
