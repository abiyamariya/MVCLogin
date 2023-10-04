using MVCLogin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCLogin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Authorize(MVCLogin.Models.User userModel)
        {
            using(LoginDataBaseEntities db=new LoginDataBaseEntities())
            {
                var userDetails = db.Users.Where(x => x.UserName == userModel.UserName && x.Password == userModel.Password).FirstOrDefault();
                if(userDetails==null)
                {
                    userModel.LoginErrorMessage = "Wrong username or password";
                    return View("Index", userModel);
                }
                else if(userDetails.UserID==1)
                {
                    Session["userID"] = userDetails.UserID;
                    return RedirectToAction("Index", "Customer");
                }
                else
                {
                    Session["userID"] = userDetails.UserID;
                    return RedirectToAction("Index", "Member");
                }
            }
        }
    }
}