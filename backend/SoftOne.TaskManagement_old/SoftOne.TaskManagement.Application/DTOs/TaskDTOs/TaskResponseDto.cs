using System;
using System.Collections.Generic;
using System.Text;

namespace SoftOne.TaskManagement.Application.DTOs.TaskDTOs
{
    public class TaskResponseDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
