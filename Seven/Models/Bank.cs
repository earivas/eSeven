using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Seven.Models
{
    public class Bank
    {
        [Key]
        public int BankID { get; set; }
        public string BankCode { get; set; }
        public  string BankDescription { get; set; }
        public virtual ICollection<ModelContract> ModelContracts { get; set; }
    }
}