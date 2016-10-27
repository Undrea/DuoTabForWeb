using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace DuoTabForWeb.Models
{
    public class TransactionsDataContext: DbContext
    {
        public DbSet<Transaction> Transactions { get; set; }

        // TODO: In production, you will want to use Entity Framework Code-First Migrations option 
        static TransactionsDataContext()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<TransactionsDataContext>());
        }
    }
}