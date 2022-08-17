using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using EmployeeProfile.Models;


namespace EmployeeProfile.Controllers
{

    public class AccountsController : Controller
    {
         
        // GET: Accounts
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserModel model)
        {
            using (Employee_PortalEntities context = new Employee_PortalEntities())
            {
                bool IsValidUser = context.Logins.Any(user => user.UserName.ToLower() ==
                     model.UserName.ToLower() && user.Password == model.UserPassword);
                if (IsValidUser)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    var data = context.Logins.Where(x => x.UserName == model.UserName && x.Password == model.UserPassword).FirstOrDefault();
                    TempData["UserId"] = data;
                  
                    return RedirectToAction("Index", "LeadDashboard");
                }
                ModelState.AddModelError("", "invalid Username or Password");
                return View();
            }
        }
        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(User model)
        {
            using (Employee_PortalEntities context = new Employee_PortalEntities())
            {
                context.Users.Add(model);
                context.SaveChanges();
            }

            return RedirectToAction("Login");
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}
