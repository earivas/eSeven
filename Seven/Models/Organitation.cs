using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Seven.Models
{
    public class Organitation
    {
        [Key]
        public int OrganitationID { get; set; }
        public string  Nit { get; set; }
        public string OrganitationName { get; set; }
        public string Address { get; set; }

        public virtual ICollection<ModelContract> ModelContrats { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Budget> Budgets { get; set; }
    }
    
 }
