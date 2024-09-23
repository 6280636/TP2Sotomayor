using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace JuliePro.Models
{
    public class Trainer
    {
        public int Id { get; set; }

        [Display(Name = "FirstName")]
        [StringLength(25, MinimumLength = 4, ErrorMessage = "ValidationStringMinMax")]
        //[StringLength(25, MinimumLength = 4)]
        public string FirstName { get; set; }

        [Display(Name = "LastName")]
        [StringLength(25, MinimumLength = 4, ErrorMessage = "ValidationStringMinMax")]
        //[StringLength(25, MinimumLength = 4)]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Photo")]
        [MaxLength(40, ErrorMessage = "ValidationStringMax")]
        //[MaxLength(40)]
        public string? Photo { get; set; }

        public int SpecialityId { get; set; }

        [Display(Name = "Speciality")]
        [ValidateNever]
        public virtual Speciality Speciality { get; set; }
        
        [ValidateNever]
        public virtual List<Customer> Customers { get; set; }
    }
}
