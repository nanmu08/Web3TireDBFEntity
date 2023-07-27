using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.Models;

namespace BusinessLogic
{
    public class UsersBL
    {
        public List<User> GetUsers()
        {
            List<User> usersBL = new UsersDAL().GetUsers();
            List<User> usersmodify = ModifyPassword(usersBL);
            return usersmodify;
        }
        public List<User> ModifyPassword(List<User> users)
        {
            foreach (var user in users)
            {
                user.Password = user.Password.Substring(0, user.Password.Length - 1) + "*";
            }
            return users;
        }
    }
}
