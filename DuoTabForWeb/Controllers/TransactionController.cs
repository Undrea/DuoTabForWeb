using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DuoTabForWeb.Models;
using DuoTabForWeb.ViewModels;

namespace DuoTabForWeb.Controllers
{
    public class TransactionController : Controller
    {
        // GET: Transaction
        public ActionResult Details(Transaction transaction)
        {
            // Wrap in a View Model
            return View("Details", new TransactionViewModel(transaction));
        }

        [HttpGet]
        public ActionResult Create()
        {
            var transaction = new Transaction();

            // Assume "now" as the default date
            transaction.Date = DateTime.Now;

            // Assume the payer is paying in full
            transaction.Split = 1.0M;

            return View(transaction);
        }

        [HttpPost]
        public ActionResult Create(Transaction transaction)
        {
            // TODO: Perform validation
            if (ModelState.IsValid)
            {
                // TODO: Save model to DB
                return RedirectToAction("Details", transaction);
            } else
            {
                return View(transaction); // TODO: Display errors
            }
        }
    }
}
