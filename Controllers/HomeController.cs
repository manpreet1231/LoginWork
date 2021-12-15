using LoginWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginWork.Controllers
{
    
    public class HomeController : Controller
    {
        Database1Entities db = new Database1Entities();
        [HttpGet]
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(User us)
        {
            db.Users.Add(us);
            db.SaveChanges();
            return RedirectToAction("Login");
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User us)
        {
            var obj = db.Users.Where(x => x.User_Name.Equals(us.User_Name) && x.Password.Equals(us.Password)).FirstOrDefault();
            if(obj != null)
            {
                session.setsess(0);
                return RedirectToAction("Employ");
            }
            else if(us.User_Name == "admin" && us.Password == "admin")
            {
                session.setsess(1);
                return RedirectToAction("admin");
            }
            return View();
        }
        public ActionResult Employ()
        {
            if (session.getsess() == 0)
            {
                return View();
            }
            else
            {
                return RedirectToAction("login");
            }
        }
        public ActionResult Admin()
        {
            if(session.getsess() == 1)
            {
                return View();
            }
            else
            {
                return RedirectToAction("login");
            }
        }
    }
}