using JuliePro.Models;
using System.ComponentModel.DataAnnotations;

namespace JuliePro.Models.ViewModels
{
    public class CustomerObjectivesVM
    {
        public CustomerObjectivesVM(Customer customer)
        {
            CustomerFullName = customer.FirstName + " " + customer.LastName;
            NbCompletedObjectives = customer.Objectives.Where(o => o.AchievedDate != null).Count();
            NbIncompletedObjectives = customer.Objectives.Where(o => o.AchievedDate == null).Count();
        }

        [Display(Name = "Customer's Name")]
        public string CustomerFullName { get; set; }

        [Display(Name = "Nb Completed Objectives")]
        public int NbCompletedObjectives { get; set; }

        [Display(Name = "Nb Incompleted Objectives")]
        public int NbIncompletedObjectives { get; set; }
    }
}
