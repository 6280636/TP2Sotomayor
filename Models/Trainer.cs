using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace JuliePro.Models
{
    public class Trainer
    {
        public int Id { get; set; }
        [StringLength(25, MinimumLength = 4)]
        public string FirstName { get; set; }
        [StringLength(25, MinimumLength = 4)]
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [MaxLength(40)]
        public string? Photo { get; set; }

        public int SpecialityId { get; set; }
        [ValidateNever]
        public virtual Speciality Speciality { get; set; }

        [ValidateNever]
        public virtual List<Customer> Customers { get; set; }
    }
}
