using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Seven.Models;

namespace Seven.Models
{
    public class ModelContract
    {
        [Key]
        public int ModelContractID { get; set; }
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Currency)]
        public Decimal Salary { get; set; }
        [Display(Name = "Date Admision")]
        [Required(ErrorMessage = "You must enter {0}")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        //  [DisplayFormat(DataFormatString = "{0:hh:mm}", ApplyFormatInEditMode = true)] para horas
       // [DataType(DataType.Time)]
        public DateTime DateAdmision { get; set; }
        [Display(Name = "% Percent")]
        [DisplayFormat(DataFormatString = "{0:P2}", ApplyFormatInEditMode = false)]
        public double Percent { get; set; }
        [Display(Name = "Organitation")]
        public int OrganitationID { get; set; }
        public int SupervisorID { get; set; }
        [Display(Name = "Model Type")]
        public int ModelTypeID { get; set; }

        public int ProfitCenterID { get; set; }
        [Display(Name = "EPS")]
        public int EpsID { get; set; }
        [Display(Name = "AFP")]
     
        public int AfpID { get; set; }
        [Display(Name = "ARL")]
        public int ArlID { get; set; }
        [Display(Name = "Compensation")]
        public int CompensationID { get; set; }
        public int BankID { get; set; }

        public virtual Organitation Organitation { get; set; }
        public virtual Supervisor Supervisor { get; set; }
        public virtual ModelType ModelType { get; set; }
        public virtual ProfitCenter ProfitCenter { get; set; }
        public virtual Eps Eps { get; set; }
        public virtual Afp Afp { get; set; }
        public virtual Arl Arl { get; set; }
        public virtual Compensation Compensation { get; set; }
        public virtual Bank Bank { get; set; }



    }
}