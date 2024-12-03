using APITaskManager.AppServices.Interfaces;
using APITaskManager.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace APITaskManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectAppService _projectAppService;

        public ProjectsController(IProjectAppService projectAppService)
        {
            _projectAppService = projectAppService;
        }

        [HttpGet]
        [Route("GetProjects")]
        public async Task<IActionResult> GetProjects()
        {
            var projects = await _projectAppService.GetAllProjectsAsync();
            return Ok(projects);
        }

        [HttpPost]
        [Route("CreateProject")]
        public async Task<IActionResult> CreateProject([FromBody] ProjectViewModel dto)
        {
            var project = await _projectAppService.CreateProjectAsync(dto);
            if (project.Id != 0)
            {
                return BadRequest("Não foi possivel Criar o Projeto");
            }
            return Ok("Tarefa Criada Com sucesso");
        }

        [HttpDelete]
        [Route("DeleteProject")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var result = await _projectAppService.DeleteProjectAsync(id);
            if (result.Id != 0)
            {
                return BadRequest("Não foi possivel deletar o Projeto");
            }
            return Ok("Deletado com Sucesso");
        }
    }
}
