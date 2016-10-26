using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DuoTabForWeb.Enums;
using System.ComponentModel.DataAnnotations;

namespace DuoTabForWeb.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.Currency), Display(Name = "Amount")]
        public decimal Amount { get; set; }

        [DataType(DataType.Date),Display(Name = "Transaction Date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Display(Name = "User Who Made Transaction")]
        public UserType User { get; set; }

        [Display(Name = "Proportion To Be Paid By You"), Range(0, 1, ErrorMessage = "Proportion should be between 0 and 1, inclusive.")]
        public decimal Split { get; set; }

        [Display(Name = "Expense Type")]
        public ExpenseType Type { get; set; }

        [Display(Name = "Notes"), DataType(DataType.MultilineText), StringLength(50, ErrorMessage = "Notes should not be longer than 500 characters.")]
        public string Notes { get; set; }
    }
}
