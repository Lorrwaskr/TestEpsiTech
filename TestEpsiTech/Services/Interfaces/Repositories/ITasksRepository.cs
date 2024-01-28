using TestEpsiTech.Models.Entities;

namespace TestEpsiTech.Services.Interfaces.Repositories
{
    public interface ITasksRepository
    {
        Task<TaskModel?> GetAsync(int id);
        Task<List<TaskModel>> GetAllAsync();
        Task<TaskModel> CreateAsync(TaskModel model);
        Task<TaskModel?> UpdateAsync(TaskModel model);
        Task<TaskModel?> DeleteAsync(int id);
    }
}
