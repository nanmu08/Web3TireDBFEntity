using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;

namespace DataAccess
{
    public class UsersDAL
    {
        private UserDBEntities db = new UserDBEntities();
        public List<User> GetUsers()
        {
            List<User> UserList = new List<User>();
            
            UserList = db.Users.ToList();
            return UserList;
        }
        public void AddUser(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }
    }
}
