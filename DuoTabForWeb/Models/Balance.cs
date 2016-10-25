using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DuoTabForWeb.Models
{
    public class Balance
    {
        public int Id { get; set; }
        public int BalanceInCents { get; set; }

        /// <summary>
        /// Initializes the Model with a starting balance in cents (e.g. 125 cents).
        /// </summary>
        /// <param name="balance">Pass the value in cents; a negative value means "partner" owes "you".</param>
        public Balance(int balanceInCents)
        {
            BalanceInCents = balanceInCents;
        }

        /// <summary>
        /// Initializes the Model with a starting currency balance (e.g. 12.55 dollars).
        /// </summary>
        /// <param name="balanceInCurrency"></param>
        public Balance(float balanceInCurrency)
        {
            // Convert the value to an integer and round to the nearest cent
            float valueInCents = balanceInCurrency * 100;
            BalanceInCents = Convert.ToInt32(Math.Round(valueInCents));
        }
    }
}
