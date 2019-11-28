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
            List<List<string>> listUsers = new List<List<string>>();
            foreach(var item in db.Users)
            {
                listUsers.Add(new List<string> { item.id_users.ToString(), item.login, item.nom, item.prenom, item.admin.ToString() });
            }
            return View(listUsers);
        }

        public ActionResult AddUsers()
        {

            return View();
        }
    }
}