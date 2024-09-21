using JuliePro.Models;

namespace JuliePro.Models.ViewModels
{
    public class TrainerObjectivesVM
    {
        public TrainerObjectivesVM(Trainer trainer)
        {
            CollapserId = "Collapser" + trainer.Id.ToString();
            TrainerFullName = trainer.FirstName + " " + trainer.LastName;
            TrainerSpecialityName = trainer.Speciality.Name;
            CustomerObjectives = trainer.Customers.Select(customer => new CustomerObjectivesVM(customer));
        }

        public string CollapserId { get; set; }
        public string TrainerFullName { get; set; }
        public string TrainerSpecialityName { get; set; }
        public IEnumerable<CustomerObjectivesVM> CustomerObjectives { get; set; }

    }
}
