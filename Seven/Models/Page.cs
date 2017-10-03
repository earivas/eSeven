using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Seven.Models
{
    public class Page
    {
        public int PageID { get; set; }

        [Display(Name = "Page Name")]
        [Required(ErrorMessage = "You must enter {0}")]
        [StringLength(30, ErrorMessage = "The field {0} must between {1} and {2} characters", MinimumLength = 3)]
        public string PageName { get; set; }

        [Display(Name = "Url")]
        [DataType(DataType.Url)]
        public string PageUrl { get; set; }

       // [DisplayFormat(DataFormatString =   "{0:N2}", ApplyFormatInEditMode = false)]  // {0:P2} = PORCENTJE  0:#,#.##
      //  [DisplayFormat(DataFormatString = "{0:#,#.##}", ApplyFormatInEditMode = false)]
      //  [Display(Name = "Token Value")]
      //  [DataType(DataType.Currency)]
       public decimal TipValue { get; set; } // Cambiar TipValue por TokenValue

        [Display(Name = "Page Type")]
        public int PageTypeID { get; set; }
        public virtual PageType PageType { get; set; }
      //  public virtual ICollection<ModelContract> ModelContracts { get; set; }
     //   public virtual ICollection<ModelPerson> ModelPersons { get; set; }
        public virtual ICollection<ModelPage> ModelPages { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}