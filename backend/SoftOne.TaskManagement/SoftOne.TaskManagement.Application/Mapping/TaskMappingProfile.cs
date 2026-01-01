using SoftOne.TaskManagement.Application.DTOs;
using SoftOne.TaskManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;
using AutoMapper;

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
