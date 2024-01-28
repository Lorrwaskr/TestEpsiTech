using AutoMapper;
using TestEpsiTech.Models.DTOs;
using TestEpsiTech.Models.Entities;

namespace TestEpsiTech.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TaskDto, TaskModel>();
            CreateMap<TaskDto, TaskLiteDto>();
            CreateMap<TaskModel, TaskDto>();
            CreateMap<TaskModel, TaskLiteDto>();
            CreateMap<TaskLiteDto, TaskDto>();
            CreateMap<TaskLiteDto, TaskModel>();
            CreateMap<List<TaskModel>, List<TaskDto>>().ConvertUsing(MapTaskModelsToDtos);
        }

        private List<TaskDto> MapTaskModelsToDtos(List<TaskModel> taskModels, List<TaskDto> taskDtos, ResolutionContext context)
        {
            taskDtos = new List<TaskDto>();
            foreach (var taskModel in taskModels)
            {
                var taskDto = context.Mapper.Map<TaskDto>(taskModel);
                taskDtos.Add(taskDto);
            }
            return taskDtos;
        }
    }
}
