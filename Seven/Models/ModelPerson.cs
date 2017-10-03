using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Seven.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Seven.Models
{
    public class ModelPerson
    {
        [Key]
        public int ModelID { get; set; }
        [Display(Name = "Identity Card")]
        public string IdentityCard { get; set; }

        [Display(Name = "First Name")]
        [StringLength(30, ErrorMessage = "The field {0} must between {1} and {2} characters", MinimumLength = 3)]
         public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(30, ErrorMessage = "The field {0} must between {1} and {2} characters", MinimumLength = 3)]
        public string LastName { get; set; }

        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Nick { get; set; }
      
        [Required(ErrorMessage = "You must enter {0}")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [Display(Name = "Profile Type")]
        public string  ProfileType { get; set; }

        [NotMapped]
        public string FullName { get { return string.Format("{0} {1}", FirstName, LastName); } }
        public virtual ICollection<ModelContract> ModelContrats { get; set; }
        public virtual ICollection<Budget> Budgets { get; set; }
      
        public virtual ICollection<ModelPage> ModelPages { get; set; }

    }
}