using System.ComponentModel.DataAnnotations;

namespace JuliePro.Models
{
    public class Speciality
    {
        public int Id { get; set; }
        [StringLength(20, MinimumLength = 5)]
        public string Name { get; set; }
        public virtual List<Trainer> Trainers { get; set; }
    }
}
