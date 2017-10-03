using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Seven.Models
{
    public class ProfitCenter
    {
        [Key]
        public int ProfitCenterID { get; set; }
        [Display(Name = "Profit Center")]
        [Required(ErrorMessage = "You must enter {0}")]
        [StringLength(30, ErrorMessage = "The field {0} must between {1} and {2} characters", MinimumLength = 3)]
         public string ProfitCenterDescription { get; set; }
     //   public string AdministratorName { get; set; }
        public virtual ICollection<ModelContract> ModelContracts { get; set; }
    }
}