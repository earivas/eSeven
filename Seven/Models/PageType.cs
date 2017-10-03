using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Seven.Models
{
    public class PageType
    {
        public int PageTypeID { get; set; }
        [Display(Name = "Page Type")]
        [Required(ErrorMessage = "You must enter {0}")]
        [StringLength(30, ErrorMessage = "The field {0} must between {1} and {2} characters", MinimumLength = 3)]
        public string PageTypeDescription { get; set; }
        public virtual ICollection<Page> Pages { get; set; }
     
    }
}