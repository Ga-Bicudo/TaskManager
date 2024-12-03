
using APITaskManager.Domain;

namespace APITaskManager.Services.Interfaces
{
    public interface ITaskService
    {
        Task<Domain.Task> CreateTaskAsync(Domain.Task task);
        Task<bool> DeleteTaskAsync(int taskId);
        Task<IEnumerable<Domain.Task>> GetTasksByProjectAsync(int projectId);
        Task<Domain.Task> UpdateTaskAsync(Domain.Task task);
    }
}
