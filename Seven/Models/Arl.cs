using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Seven.Models
{
    public class Arl
    {
        public int ArlID { get; set; }
        [Display(Name = "ARL")]
        public string ArlDescription { get; set; }
        public virtual ICollection<ModelContract> ModelContracts { get; set; }
    }
}