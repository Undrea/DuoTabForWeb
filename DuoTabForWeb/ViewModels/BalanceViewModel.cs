using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DuoTabForWeb.Models;


namespace DuoTabForWeb.ViewModels
{
    public class BalanceViewModel
    {
        // Balance is positive if "you" owes their partner.
        public Balance CurrentBalance { get; set; }

        /// <summary>
        /// Initializes the ViewModel with the Model.
        /// </summary>
        public BalanceViewModel(Balance balance)
        {
            CurrentBalance = balance;
        }

        /// <summary>
        /// Returns the actual currency value of the balance owed to either party.
        /// </summary>
        public double CurrencyValue
        {
            get
            {
                double currencyBalance = Convert.ToDouble(CurrentBalance.BalanceInCents) / 100.0;
                return Math.Round(Math.Abs(currencyBalance), 2); // Round to the nearest cent
            }
        }

        /// <summary>
        /// The dollars portion of the balance, unrounded for the cent portion.
        /// </summary>
        public int Dollars
        {
            get
            {
                int dollars = Convert.ToInt32(CurrentBalance.BalanceInCents / 100);
                return Math.Abs(dollars); // Remove the potential negative
            }
        }

        /// <summary>
        /// The cents portion of the balance, rounded to the nearest cent.
        /// </summary>
        public int Cents
        {
            get
            {
                return Math.Abs(CurrentBalance.BalanceInCents % 100);
            }
            
        }

        /// <summary>
        /// Returns true if the partner owes "you," the authenticated user.
        /// </summary>
        public bool IsPartnerOwing
        {
            get
            {
                return CurrentBalance.BalanceInCents >= 0;
            }
        }
    }
}