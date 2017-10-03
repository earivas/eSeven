using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Seven.Models;


namespace Seven.Models
{
    public class ModelPage
    {
        [Key]
        public int ID { get; set; }
        public int ModelID { get; set; }
        public int PageID { get; set; }

        public virtual ModelPerson ModelPresons { get; set; }
        public virtual Page Pages { get; set; }
        //  public virtual ICollection<ModelContract> ModelContracts { get; set; }
    }
}