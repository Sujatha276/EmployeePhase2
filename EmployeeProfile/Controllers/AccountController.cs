using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using EmployeeProfile.Models;

namespace EmployeeProfile.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User model)
        {
            using (Employee_PortalEntities context = new Employee_PortalEntities())


            {
                bool IsValidUser = context.Users.Any(user => user.UserName.ToLower() ==
                     model.UserName.ToLower() && user.Password == model.Password);

                if (IsValidUser)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    var data = context.Users.Where(x => x.UserName == model.UserName && x.Password == model.Password).FirstOrDefault();
                    //TempData["UserId"] = data;
                    


                    //ViewBag.profit_Loss = Lead_p_l;
                    return RedirectToAction("Index","EmployeeDetails");
                }

                //ViewBag.profit_Loss = context;
                //return View("master_emp_detail", context);


                ModelState.AddModelError("", "invalid Username or Password");
                return View("EmployeeDetails");
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
    