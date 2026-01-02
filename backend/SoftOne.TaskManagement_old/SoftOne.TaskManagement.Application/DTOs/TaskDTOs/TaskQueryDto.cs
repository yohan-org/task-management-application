using System;
using System.Collections.Generic;
using System.Text;

namespace SoftOne.TaskManagement.Application.DTOs.TaskDTOs
{
    public class TaskQueryDto
    {
        public bool? IsCompleted { get; set; }
        public string? SortBy { get; set; } // title | createdAt
        public bool Desc { get; set; }
    }
}
