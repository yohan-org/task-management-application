using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoftOne.TaskManagement.Application.DTOs.TaskDTOs;
using SoftOne.TaskManagement.Application.Services;
using SoftOne.TaskManagement.Domain.Entities;

namespace SoftOne.TaskManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly TaskService _service;
        private readonly IMapper _mapper;

        public TasksController(TaskService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET api/tasks
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var tasks = await _service.GetTasksAsync();
            var dto = _mapper.Map<IEnumerable<TaskResponseDto>>(tasks);
            return Ok(dto);
        }

        // GET api/tasks/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var task = await _service.GetTaskAsync(id);
            if (task == null) return NotFound();

            var dto = _mapper.Map<TaskResponseDto>(task);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateTaskDto dto)
        {
            var task = _mapper.Map<TaskItem>(dto);
            await _service.AddTaskAsync(task);
            return Ok(_mapper.Map<TaskItemDto>(task));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateTaskDto dto)
        {
            if (id != dto.Id) return BadRequest();

            var entity = _mapper.Map<TaskItem>(dto);
            await _service.UpdateTaskAsync(entity);

            return NoContent();
        }

        // DELETE api/tasks/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteTaskAsync(id);
            return NoContent();
        }
    }
}
