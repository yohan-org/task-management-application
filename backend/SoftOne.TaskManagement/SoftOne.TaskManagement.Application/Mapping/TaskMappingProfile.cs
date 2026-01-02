using AutoMapper;
using SoftOne.TaskManagement.Application.DTOs.TaskDTOs;
using SoftOne.TaskManagement.Domain.Entities;

namespace SoftOne.TaskManagement.Application.Mapping
{
    public class TaskMappingProfile : Profile
    {   
        public TaskMappingProfile()
        {
            CreateMap<TaskItem, TaskItemDto>().ReverseMap();
            CreateMap<CreateTaskDto, TaskItem>();
            CreateMap<UpdateTaskDto, TaskItem>();
            CreateMap<TaskItem, TaskResponseDto>();
        }
    }
}
