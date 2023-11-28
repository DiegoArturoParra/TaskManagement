using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TemplateCRUDNet7.Dtos;
using TemplateCRUDNet7.Repositories.Interfaces;

namespace TemplateCRUDNet7.Controllers
{
    [Route("api/task-user")]
    [ApiController]
    public class TaskUserController : ControllerBase
    {
        private readonly ILogger<TaskUserController> _logger;
        private readonly ITaskUserRepository _repository;
        public TaskUserController(ILogger<TaskUserController> logger, ITaskUserRepository branchOfficeRepository)
        {
            _logger = logger;
            _repository = branchOfficeRepository;
        }


        [HttpGet]
        [Authorize]
        [Route("list")]
        public async Task<IActionResult> ListTasksOfUser()
        {
            var listado = await _repository.GetTasksByUser();
            return Ok(listado);
        }

        [HttpGet]
        [Authorize]
        [Route("detail/{TaskId}")]
        public async Task<IActionResult> TaskOfUser(Guid TaskId)
        {
            var task = await _repository.GetDetailTaskByUser(TaskId);
            return Ok(task);
        }

        [HttpPost]
        [Authorize]
        [Route("create")]
        public async Task<IActionResult> CreateTaskByUser([FromBody] TaskCreateDto createTask)
        {
            var response = await _repository.CreateTask(createTask);
            return StatusCode((int)response.StatusCode, response);
        }

        [HttpPut]
        [Authorize]
        [Route("completed/{id}")]
        public async Task<IActionResult> CompletedTask(Guid id)
        {
            var response = await _repository.CompletedTask(id);
            return StatusCode((int)response.StatusCode, response);
        }

        [HttpPut]
        [Authorize]
        [Route("soft-delete/{id}")]
        public async Task<IActionResult> SoftDeleteTask(Guid id)
        {
            var response = await _repository.SoftDeleteTask(id);
            return StatusCode((int)response.StatusCode, response);
        }
    }
}