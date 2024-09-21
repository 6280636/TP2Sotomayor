using System.ComponentModel.DataAnnotations;

namespace JuliePro.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [StringLength(25, MinimumLength = 4)]
        public string FirstName { get; set; }
        [StringLength(25, MinimumLength = 4)]
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }
        [Range(100,400)]
        public double? StartWeight { get; set; }

        public int TrainerId { get; set; }
        public virtual Trainer Trainer { get; set; }

        public virtual List<Objective> Objectives { get; set; }
    }
}
