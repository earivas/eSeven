using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Seven.Models.ViewModels
{
    public class OrderView

    {
          public ModelPerson ModelPerson { get; set; } //customer
          public PageOrder Order { get; set; } 
          public List<PageOrder> Pages { get; set; } //productos
        //  public Page Page { get; set; } //revisar


    }
}