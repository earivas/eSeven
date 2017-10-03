using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Seven.Models
{
    public class Compensation
    {
        [Key]
        public int CompensationID { get; set; }
        [Display(Name = "Compensation")]
        public string CompensationDescription { get; set; }
        public virtual ICollection<ModelContract> ModelContracts { get; set; }
    }
}