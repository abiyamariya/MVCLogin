using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCLogin.Models;

namespace MVCLogin.Controllers
{
    public class MemberController : Controller
    {
        // GET: Member
        public ActionResult Index()
        {
            using (DbModels dbModel = new DbModels())
            {
                return View(dbModel.Customers.ToList());
            }
        }
    }
}