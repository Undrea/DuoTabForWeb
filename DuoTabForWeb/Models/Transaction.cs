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
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Amount"), DataType(DataType.Currency, ErrorMessage = "Please enter a currency value, to the nearest cent."), Range(0.001, int.MaxValue, ErrorMessage = "Please enter a positive monetary amount.")]
        [RegularExpression(@"-?[0-9]+(\.[0-9][0-9]?)?", ErrorMessage = "Please enter a currency value, to the nearest cent.")]
        public decimal Amount { get; set; }

        [Required]
        [Display(Name = "User Who Made Transaction")]
        public UserType User { get; set; }

        [Display(Name = "Transaction Date"), DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }       

        [Display(Name = "Proportion To Be Paid User Who Made Transaction"), Range(0, 1, ErrorMessage = "Proportion should be between 0 and 1, inclusive.")]
        public decimal Split { get; set; }

        [Display(Name = "Expense Type")]
        public ExpenseType Type { get; set; }

        [Display(Name = "Notes"), DataType(DataType.MultilineText), StringLength(500, ErrorMessage = "Notes should not be longer than 500 characters.")]
        public string Notes { get; set; }
    }
}
