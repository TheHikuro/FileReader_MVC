using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FileReader.Models;

namespace FileReader.Controllers
{
    public class AdminController : Controller
    {
        Database_CandriamEntities db = new Database_CandriamEntities();
        // GET: Admin
        public ActionResult Index()
        {
            
            
            if (Request.Form["AddUsers"] != null)
            {
                return RedirectToAction("AddUsers", "Admin");
            }

            if(Request.Form["ListUsers"] != null)
            {
                return RedirectToAction("ListUsers", "Admin");
            }
            return View();
        }

        public ActionResult AddUsers()
        {
            Users user = new Users();
            if(Request.Form["prenom"] != null && Request.Form["nom"] != null && Request.Form["login"] != null && Request.Form["password"] != null && Request.Form["admin"] != null)
            {
                List<List<string>> listUsers = new List<List<string>>();
                foreach (var item in db.Users)
                {
                    listUsers.Add(new List<string> { item.id_users.ToString(), item.login, item.nom, item.prenom, item.admin.ToString() });
                }
                
            }
            return View();
        }

        public ActionResult ListUsers()
        {
            
            return View();
        }
    }
}