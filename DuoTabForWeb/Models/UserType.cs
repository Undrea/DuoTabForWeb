using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace DuoTabForWeb.Enums
{
    public enum UserType
    {
        [Display(Name = "Me")]
        [Display(Name = "My Partner")]
        Partner = 1
    }
}
