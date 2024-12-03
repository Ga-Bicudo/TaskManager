using APITaskManager.AppServices.Interfaces;
using APITaskManager.Domain;
using APITaskManager.Services;
using APITaskManager.Services.Interfaces;
using APITaskManager.ViewModels;
using AutoMapper;

namespace APITaskManager.appService
{
    public class ProjectAppService : IProjectAppService
    {
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;

        public ProjectAppService(IProjectService projectService, IMapper mapper)
        {
            _projectService = projectService;
            _mapper = mapper;
        }

        public async Task<ProjectViewModel> CreateProjectAsync(ProjectViewModel dto)
        {
            return _mapper.Map<ProjectViewModel>(await _projectService.CreateProjectAsync(_mapper.Map<Project>(dto)));
        }

        public async Task<ProjectViewModel> DeleteProjectAsync(int id)
        {
            return _mapper.Map<ProjectViewModel>(await _projectService.DeleteProjectAsync(id));
        }

        public async Task<IEnumerable<ProjectViewModel>> GetAllProjectsAsync()
        {
            return _mapper.Map<IEnumerable<ProjectViewModel>>(await _projectService.GetAllProjectsAsync());
        }
    }
}
