using JuliePro.Data;
using JuliePro.Models;

namespace JuliePro.Services
{
    public class TrainerService: ServiceBaseAsync<Trainer>, ITrainerServices
    {
        public TrainerService(JulieProDbContext dbContext) : base(dbContext) { }
    }
}
