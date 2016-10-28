using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DuoTabForWeb.ViewModels;
using DuoTabForWeb.Models;

namespace DuoTabForWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                // TODO: Load user's actual balance from and save to DB
                return View("AuthenticatedHome", new BalanceViewModel(new Balance(10.99f)));
            } else
            {
                return View();
            }            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}