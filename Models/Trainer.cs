using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace JuliePro.Models
{
    public class Trainer
    {
        public int Id { get; set; }

        [Display(Name = "FirstName")]
        [StringLength(25, MinimumLength = 4, ErrorMessage = "ValidationStringMinMax")]
        
        public string FirstName { get; set; }

        [Display(Name = "LastName")]
        [StringLength(25, MinimumLength = 4, ErrorMessage = "ValidationStringMinMax")]
        
        public string LastName { get; set; }

        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Photo")]
        [MaxLength(40, ErrorMessage = "ValidationStringMax")]
        //[MaxLength(40)]
        public string? Photo { get; set; }

        [Display(Name = "SpecialityId")]
        public int SpecialityId { get; set; }

        [Display(Name = "Description")]
        [MaxLength(2500, ErrorMessage = "DescriptionMessage")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "Speciality")]
        [ValidateNever]
        public virtual Speciality Speciality { get; set; }

        [Display(Name = "Customers")]
        [ValidateNever]
        public virtual List<Customer> Customers { get; set; }
    }
}
