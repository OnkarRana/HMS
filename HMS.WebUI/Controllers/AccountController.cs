using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HMS.WebUI.Controllers
{
    public class AccountController : Controller
    {
       [ HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                //Here we are checking the values with hardcoded admin and admin
                //You can check these values from a database
                
                    HMS.BL.SecurityRep item = new BL.SecurityRep();
                    UserModel record = item.getLogin(model);
                if (record != null)
                {
                    string[] roles = item.GetRolesForUser(model.UserName);
                    Session["userName"] = record.UserName;
                    Session["userID"] = record.ID;
                    Session["Roles"] = roles;
                    //FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                    // record.ID, record.UserName, DateTime.Now,DateTime.Now.AddMinutes(30),  true,  roles.Split(','),FormsAuthentication.FormsCookiePath);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View(model);
                }
               
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

    }
}