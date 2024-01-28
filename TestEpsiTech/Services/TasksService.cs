using AutoMapper;
using TestEpsiTech.Models.DTOs;
using TestEpsiTech.Models.Entities;
using TestEpsiTech.Services.Interfaces.Repositories;
using TestEpsiTech.Services.Interfaces.Services;

namespace TestEpsiTech.Services
{
    public class TasksService : ITasksService
    {
        private readonly ITasksRepository _tasksRepository;
        private readonly IMapper _mapper;

        public TasksService(ITasksRepository tasksRepository, IMapper mapper)
        {
            _tasksRepository = tasksRepository;
            _mapper = mapper;
        }

        public async Task<TaskDto> CreateTaskAsync(TaskLiteDto model)
        {
            var taskModel = _mapper.Map<TaskModel>(model);
            var createdTask = await _tasksRepository.CreateAsync(taskModel);
            return _mapper.Map<TaskDto>(createdTask);
        }

        public async Task<TaskDto?> GetTaskByIdAsync(int id)
        {
            var taskModel = await _tasksRepository.GetAsync(id);
            return _mapper.Map<TaskDto>(taskModel);
        }

        public async Task<List<TaskDto>> GetTasksAsync()
        {
            var tasks = await _tasksRepository.GetAllAsync();
            return _mapper.Map<List<TaskDto>>(tasks);
        }

        public async Task<TaskDto?> UpdateTaskAsync(TaskLiteDto model, int id)
        {
            var taskModel = _mapper.Map<TaskModel>(model);
            taskModel.Id = id;
            var updatedTask = await _tasksRepository.UpdateAsync(taskModel);
            return _mapper.Map<TaskDto>(updatedTask);
        }

        public async Task<TaskDto?> DeleteTaskAsync(int id)
        {
            var deletedTask = await _tasksRepository.DeleteAsync(id);
            return _mapper.Map<TaskDto>(deletedTask);
        }
    }
}
