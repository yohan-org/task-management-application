using System;
using System.Collections.Generic;
using System.Text;

namespace SoftOne.TaskManagement.Application.DTOs.TaskDTOs
{
    public class TaskItemDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
    }
}
