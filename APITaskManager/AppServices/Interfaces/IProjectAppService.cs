
using APITaskManager.ViewModels;

namespace APITaskManager.AppServices.Interfaces
{
    public interface IProjectAppService
    {
        Task<ProjectViewModel> CreateProjectAsync(ProjectViewModel dto);
        Task<ProjectViewModel> DeleteProjectAsync(int id);
        Task<IEnumerable<ProjectViewModel>> GetAllProjectsAsync();
    }
}
