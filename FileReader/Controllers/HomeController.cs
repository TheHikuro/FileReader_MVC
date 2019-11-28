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
    public class HomeController : Controller
    {
        Database_CandriamEntities db = new Database_CandriamEntities();

        public ActionResult Index()
        {
            //Authentification Visiteur
            if (Request.HttpMethod == "POST")
            {
                if (Request.Form["LoginUsers"] != null && Request.Form["PasswordUsers"] != null)
                {
                    string login = Request.Form["LoginUsers"].Trim();
                    string pass = Request.Form["PasswordUsers"].Trim();
                        foreach (var item in db.Users.ToList())
                        {
                            if (login == item.login.Trim() && pass == item.password.Trim())
                            {
                                Session["idUsers"] = item.id_users;
                                int? adm = item.admin;
                                if(adm == 2)
                            {
                                return RedirectToAction("Index", "Admin");
                            }
                            else
                            {
                                return RedirectToAction("index", "Formulaire");
                            }
                            }
                            else if(login != item.login.Trim() && pass != item.password.Trim())
                        {
                            //Request.Form["hiddenPhrase"] //change le visibilité du style 
                        }
                        }
                }

            }
            return View();
        }
    }
}