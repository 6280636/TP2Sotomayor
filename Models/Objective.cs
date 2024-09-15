using System.ComponentModel.DataAnnotations;

namespace JuliePro.Models
{
    public class Objective
    {
        public int Id { get; set; }
        [StringLength(15, MinimumLength = 5)]
        public string Name { get; set; }
        [Range(2, 10)]
        public double? LostWeightKg { get; set; }
        [Range(2, 45)]
        public double? DistanceKm { get; set; }
        public DateTime? AchievedDate { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
