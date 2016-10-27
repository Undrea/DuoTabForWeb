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
        {
        {
           // Wrap in a View Model
           var db = new TransactionsDataContext();
           var transaction = db.Transactions.Find(id);

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
            if (ModelState.IsValid)
            {
                var db = new TransactionsDataContext();
                db.Transactions.Add(transaction);
                db.SaveChanges();

                return RedirectToAction("Details", new { transaction.Id } );
            } else
            {
                return View(transaction); // TODO: Display errors
            }
        }
    }
}
