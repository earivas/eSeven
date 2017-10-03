using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Seven.Models
{
    public class ModelType
    {
        public int ModelTypeID { get; set; }
        [Display(Name = "Model Type")]
        public string ModelTypeDescription { get; set; }
        public virtual ICollection<ModelContract> ModelContracts { get; set; }
    }
}