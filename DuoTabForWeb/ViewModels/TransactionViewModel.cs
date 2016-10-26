using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DuoTabForWeb.Models;

namespace DuoTabForWeb.ViewModels
{
    public class TransactionViewModel
    {
        public Transaction CurrentTransaction { get; set; }

        /// <summary>
        /// Initializes the ViewModel with the Model.
        /// </summary>
        public TransactionViewModel(Transaction transaction)
        {
            CurrentTransaction = transaction;
        }

        /// <summary>
        /// Returns a string of information about the transaction payer and split proportion (percent and amount paid by payer).
        /// </summary>
        public string SplitInformation
        {
            get
            {
                if (CurrentTransaction.Split == 0)
                {
                    return CurrentTransaction.User.ToString() + "paid, but is owed 100% of of this expense.";
                }
                else if (CurrentTransaction.Split == 1)
                {
                    return CurrentTransaction.User.ToString() + "paid, and is owed 100% of this expense.";
                }
                else
                {
                    var splitPaidByPayer = Math.Round(CurrentTransaction.Amount * CurrentTransaction.Split, 2);
                    var percentPaidByPayer = Math.Round(CurrentTransaction.Split * 100, 0);

                    return "With a " + percentPaidByPayer + "% split, the payer (" + CurrentTransaction.User.ToString().ToLower() + ") will only cover $" + splitPaidByPayer + ".";
                }
            }           
        }
    }
}
