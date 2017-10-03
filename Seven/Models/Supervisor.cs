using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Seven.Models
{
    //  [Table("NombreTabla")] Para cambiar el nombre de la tabla en la tabla de la base de datos
    public class Supervisor
    {

        [Key]
        public int SupervisorID { get; set; }

        //[Column("Name")] Para cambiar el nombre del campo en la tabla de la base de datos
        [Display(Name = "Identity Card")]
        [Required(ErrorMessage ="You must enter {0}")]
        public string IdentityCard { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "You must enter {0}")]
        [StringLength(30, ErrorMessage ="The field {0} must between {1} and {2} characters",MinimumLength =3)]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "You must enter {0}")]
        [StringLength(30, ErrorMessage = "The field {0} must between {2} and {1} characters", MinimumLength = 3)]
        public string LastName { get; set; }
  
        public string Address { get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "You must enter {0}")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        // public DateTime DateAdmision { get; set; }
        [Display(Name = "Profile Type")]
        [Required(ErrorMessage = "You must enter {0}")]
        public string ProfileType { get; set; }
        [NotMapped]
        public int Age { get { return DateTime.Now.Year - BirthDate.Year; } }
        [NotMapped]
        public string FullName { get { return string.Format("{0} {1}", FirstName, LastName); } } 
        public virtual ICollection<ModelContract> ModelContrats { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}