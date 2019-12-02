using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FileReader.Models;
using System.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


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
                            string message = "Username and/or password is incorrect.";
                            ViewBag.Message = message;
                            return RedirectToAction("index", "Home");
                        }
                        }
                }

            }
            return View();
        }
    }
}