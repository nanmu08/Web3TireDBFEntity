using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//add bussiness and dataAccess
using BusinessLogic;
using DataAccess;
using DataAccess.Models;
// used for presentation layer RegisterView model
using Web3TireDBFEntity.Models;
using System.ComponentModel.DataAnnotations;

namespace Web3TireDBFEntity.Controllers
{
    public class UserController : Controller
    {
        UsersDAL usersDAL = new UsersDAL();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        //GET UserList
        public ActionResult UserList()
        {

            UsersBL usersBL = new UsersBL();
            List<User> usersFromDAL = usersBL.GetUsers();
            return View(usersFromDAL);

        }

        public ActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]
        public ActionResult RegisterSubmit(RegisterView newUser)
        {

            if (ModelState.IsValid)
            {
                User user = new User
                {
                    UserId = newUser.UserId,
                    UserName = newUser.UserName,
                    Email = newUser.Email,
                    Password = newUser.Password
                };

                usersDAL.AddUser(user);

                return View("RegisterSubmit", newUser);
            }
            else
            {
                return View("Register", newUser);
            }
        }
    }
}