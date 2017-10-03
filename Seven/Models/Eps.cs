using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Seven.Models
{
    public class Eps
    {
        public int EpsID { get; set; }
        [Display(Name = "EPS")]
        public string EpsDescription { get; set; }
        public virtual ICollection<ModelContract> ModelContracts { get; set; }
    }
}