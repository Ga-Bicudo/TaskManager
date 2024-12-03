using APITaskManager.Domain;

namespace APITaskManager.Services.Interfaces
{
    public interface IProjectService
    {
        Task<Project> CreateProjectAsync(Project project);
        Task<Project> DeleteProjectAsync(int id);
        Task<IEnumerable<Project>> GetAllProjectsAsync();
    }
}
