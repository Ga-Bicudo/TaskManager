using APITaskManager.AppServices.Interfaces;
using APITaskManager.Domain;
using APITaskManager.Repository;
using APITaskManager.Repository.Interfaces;
using APITaskManager.Services.Interfaces;

namespace APITaskManager.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly ITaskRepository _taskRepository;

        public ProjectService(IProjectRepository projectRepository, ITaskRepository taskRepository)
        {
            _projectRepository = projectRepository;
            _taskRepository = taskRepository;
        }

        public async Task<Project> CreateProjectAsync(Project project)
        {
            try
            {
                await _projectRepository.AddAsync(project);
                await _projectRepository.SaveChangesAsync();
                return project;
            }
            catch (Exception)
            {
                project.Id = 0;
                return project; 
            }
        }

        public async Task<Project> DeleteProjectAsync(int id)
        {
            try
            {
                var tasks = await _taskRepository.GetTasksByProjectIdAsync(id);
                if (tasks.Any(t => t.Status != Utils.TaskStatus.Completed))
                {
                    throw new InvalidOperationException("O projeto não pode ser excluído enquanto houver tarefas pendentes.");
                }

                var project = await _projectRepository.GetByIdAsync(id);
                if (project == null)
                {
                    throw new KeyNotFoundException("Projeto não encontrado.");
                }

                _projectRepository.Delete(project);
                await _projectRepository.SaveChangesAsync();
                return project;
            }
            catch (Exception)
            {
                throw ;
            }
        }

        public async Task<IEnumerable<Project>> GetAllProjectsAsync()
        {
            return await _projectRepository.GetProjectsByUserIdAsync();
        }
    }
}
