
using APITaskManager.ViewModels;

namespace APITaskManager.AppServices.Interfaces
{
    public interface ITaskAppService
    {
        Task<TaskViewModel> CreateTaskAsync(TaskViewModel dto);
        Task<bool> DeleteTaskAsync(int taskId);
        Task<IEnumerable<TaskViewModel>> GetTasksByProjectAsync(int projectId);
        Task<TaskViewModel> UpdateTaskAsync(TaskViewModel dto);
    }
}
