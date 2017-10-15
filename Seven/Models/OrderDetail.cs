using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Seven.Models
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailID { get; set; }
        public int OrderID { get; set; }
        public int PageID { get; set; }


        [Display(Name = "Page Name")]
        [Required(ErrorMessage = "You must enter {0}")]
        [StringLength(30, ErrorMessage = "The field {0} must between {1} and {2} characters", MinimumLength = 3)]
        public string PageName { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        [Display(Name = "Token Value")]
        public decimal TipValue { get; set; } // Cambiar TipValue por TokenValue

        [Display(Name = "Token Qty")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Currency)]
        public int QtyTokens { get; set; }

        [DataType(DataType.Currency)]
        public Decimal Value { get; set; }

        [Display(Name = "Start Time")]
   //    [DisplayFormat(DataFormatString = "{0:hh:mm}", ApplyFormatInEditMode = true)]
    //   [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm}", ApplyFormatInEditMode = true)]
       [DataType(DataType.DateTime)]
        public DateTime  TimeStart { get; set; }

       [Display(Name = "End Time")]
      // [DisplayFormat(DataFormatString = "{0:hh:mm}", ApplyFormatInEditMode = true)]
     // [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm}", ApplyFormatInEditMode = true)]
       [DataType(DataType.DateTime)]
        public DateTime TimeEnd { get; set; }


        public DateTime CreationDate { get; set; }
        public virtual Order Orders { get; set; }
        public virtual Page Pages { get; set; }
    }
}

