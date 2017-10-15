using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Seven.Models
{
    public class PageOrder:Page

    {

        [Display(Name = "Token Qty")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Currency)]

        public int QtyTokens { get; set; }

        [Display(Name = "Value")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Currency)]
        public Decimal Value { get; set; }
        

        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Currency)]
        public decimal Total { get { return TipValue * QtyTokens ; } }


        [Display(Name = "Start Time")]
  //      [DisplayFormat(DataFormatString = "{0:hh:mm}", ApplyFormatInEditMode = true)]
       [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime)]
        public DateTime TimeStart { get; set; }

        [Display(Name = "End Time")]
     //   [DisplayFormat(DataFormatString = "{0:hh:mm}", ApplyFormatInEditMode = true)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime)]
        public DateTime TimeEnd { get; set; }

        [Display(Name = "CreationDate")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }

        [Display(Name = "CreationDate")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
         public DateTime OrderDate { get; set; }

    }
}