using APITaskManager.AppServices;
using APITaskManager.AppServices.Interfaces;
using APITaskManager.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace APITaskManager.Controllers
{
    [ApiController]
    [Route("api/tasks/")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskAppService _taskAppService;

        public TaskController(ITaskAppService taskAppService)
        {
            _taskAppService = taskAppService;
        }

        [HttpGet]
        [Route("GetTasks")]
        public async Task<IActionResult> GetTasks(int projectId)
        {
            var tasks = await _taskAppService.GetTasksByProjectAsync(projectId);
            return Ok(tasks);
        }

        [HttpPost]
        [Route("CreateTask")]
        public async Task<IActionResult> CreateTask([FromBody] TaskViewModel dto)
        {
            var task = await _taskAppService.CreateTaskAsync( dto);
            return CreatedAtAction(nameof(GetTasks), new { projectId = task.ProjectId }, task);
        }

        [HttpPut]
        [Route("UpdateTask")]
        public async Task<IActionResult> UpdateTask([FromBody] TaskViewModel dto)
        {
            var result = await _taskAppService.UpdateTaskAsync(dto);
            if (!result.Status.Equals(Utils.TaskStatus.Completed))
            {
                return BadRequest("Taréfa não pode ser Atualizada");
            }
            return Ok("Atualização Realizada com Sucesso");
        }

        [HttpDelete]
        [Route("DeleteTask")]
        public async Task<IActionResult> DeleteTask(int taskId)
        {
            var result = await _taskAppService.DeleteTaskAsync(taskId);
            if (!result)
            {
                return BadRequest("Taréfa não pode ser Deletada");
            }
            return NoContent();
        }
    }
}
