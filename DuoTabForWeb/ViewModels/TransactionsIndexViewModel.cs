using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DuoTabForWeb.ViewModels;

namespace DuoTabForWeb.ViewModels
{
    public class TransactionsIndexViewModel
    {
        public TransactionViewModel[] TransactionViewModels { get; set; }

        public TransactionsIndexViewModel(TransactionViewModel[] transactionViewModels)
        {
            TransactionViewModels = transactionViewModels;
        }
    }
}
