using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Seven.Models
{
    public class Budget
    {
        [Key]
        public int BudgetID { get; set; }
        public int OrganitationID { get; set; }
        public int ModelID { get; set; }
        public DateTime BudgetDate { get; set; }
      
        public Decimal value { get; set; }

        public virtual Organitation Organitation { get; set; }
        public virtual ModelPerson ModelPerson { get; set; }

    }
}