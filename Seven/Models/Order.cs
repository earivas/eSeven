using Seven.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Seven.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
   
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }
        public int ModelID { get; set; }

        public OrderStatus OrderStatus { get; set; }
        //   public virtual Organitation Organitation { get; set; }
        //   public int OrganitationID { get; set; }
        //   public int PageID { get; set; }
        public virtual ModelPerson ModelPerson { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
      
    }
}