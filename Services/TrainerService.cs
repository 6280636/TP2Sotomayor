using JuliePro.Data;
using JuliePro.Models;
using Microsoft.EntityFrameworkCore;

namespace JuliePro.Services
{
    public class TrainerService: ServiceBaseAsync<Trainer>, ITrainerServices
    {
        public TrainerService(JulieProDbContext dbContext) : base(dbContext) { }


        public override async Task<IReadOnlyList<Trainer>> GetAllAsync()
        {
            
            return await _dbContext.Set<Trainer>()
                .Include(t => t.Speciality)
                .OrderBy(t => t.FirstName)
                .ThenBy(t => t.LastName)
                .ToListAsync();
                
        }

        public override async Task<Trainer?> GetByIdAsync(int id)
        {
            var trainer = await _dbContext.Set<Trainer>()
                .Include(t => t.Speciality)
                .FirstOrDefaultAsync(m => m.Id == id);

            return trainer;
        }
    }
}
