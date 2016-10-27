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
                    switch(CurrentTransaction.User)
                    {
                        case Enums.UserType.Me:
                            return "I paid, but my partner owes me 100% of this expense.";
                        case Enums.UserType.Partner:
                            return "My partner paid, but I owe 100% of this expense.";
                        default:
                            return "";
                    }
                }
                else if (CurrentTransaction.Split == 1)
                {
                    switch (CurrentTransaction.User)
                    {
                        case Enums.UserType.Me:
                            return "I paid, and will cover 100% of this expense.";
                        case Enums.UserType.Partner:
                            return "My partner paid, and will cover 100% of this expense.";
                        default:
                            return "";
                    }                    
                }
                else
                {
                    var splitPaidByPayer = Math.Round(CurrentTransaction.Amount * CurrentTransaction.Split, 2);
                    var percentPaidByPayer = Math.Round(CurrentTransaction.Split * 100, 0);

                    switch (CurrentTransaction.User)
                    {
                        case Enums.UserType.Me:
                            return "I paid with a " + percentPaidByPayer + "% split, so I will cover cover $" + splitPaidByPayer + " of this expense.";
                        case Enums.UserType.Partner:
                            return "My partner paid with a " + percentPaidByPayer + "% split, so I will cover $" + (CurrentTransaction.Amount - splitPaidByPayer) + " of this expense.";
                        default:
                            return "";
                    }
                }
            }           
        }
    }
}
