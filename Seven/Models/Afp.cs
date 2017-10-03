using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Seven.Models
{
    public class Afp
    {

        public int AfpID { get; set; }
        [Display(Name = "AFP")]
        public string AfpDescription { get; set; }
        public virtual ICollection<ModelContract> ModelContracts { get; set; }
    }
}