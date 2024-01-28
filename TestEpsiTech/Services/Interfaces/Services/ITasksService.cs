using TestEpsiTech.Models.DTOs;
using TestEpsiTech.Models.Entities;

namespace TestEpsiTech.Services.Interfaces.Services
{
    public interface ITasksService
    {
        Task<TaskDto> CreateTaskAsync(TaskDto model);
        Task<TaskDto?> GetTaskByIdAsync(int id);
        Task<List<TaskDto>> GetTasksAsync();
        Task<TaskDto?> UpdateTaskAsync(TaskDto model);
        Task<TaskDto?> DeleteTaskAsync(int id);
    }
}
