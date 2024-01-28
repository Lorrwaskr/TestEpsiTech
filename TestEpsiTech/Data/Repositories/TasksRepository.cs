using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TestEpsiTech.Data.DbContexts;
using TestEpsiTech.Models.Entities;
using TestEpsiTech.Services.Interfaces.Repositories;

namespace TestEpsiTech.Data.Repositories
{
    public class TasksRepository : ITasksRepository
    {
        private AppDbContext _dbContext;
        public TasksRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TaskModel> CreateAsync(TaskModel model)
        {
            model.CreationDate = DateTime.UtcNow;
            model.LastUpdateDate = DateTime.UtcNow;
            await _dbContext.Tasks.AddAsync(model);
            await _dbContext.SaveChangesAsync();
            return model;
        }

        public async Task<List<TaskModel>> GetAllAsync()
        {
            return await _dbContext.Tasks.ToListAsync();
        }

        public async Task<TaskModel?> GetAsync(int id)
        {
            return await _dbContext.Tasks.FindAsync(id);
        }

        public async Task<TaskModel?> UpdateAsync(TaskModel model)
        {
            var existingTask = await _dbContext.Tasks.FindAsync(model.Id);
            if (existingTask == null)
            {
                return null;
            }

            model.LastUpdateDate = DateTime.UtcNow;
            model.CreationDate = existingTask.CreationDate;
            _dbContext.Entry(existingTask).CurrentValues.SetValues(model);
            await _dbContext.SaveChangesAsync();
            return existingTask;
        }

        public async Task<TaskModel?> DeleteAsync(int id)
        {
            var existingTask = await _dbContext.Tasks.FindAsync(id);
            if (existingTask == null)
            {
                return null;
            }

            _dbContext.Tasks.Remove(existingTask);
            await _dbContext.SaveChangesAsync();
            return existingTask;
        }
    }
}
