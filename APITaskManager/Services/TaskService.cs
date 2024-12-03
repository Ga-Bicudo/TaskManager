using APITaskManager.Domain;
using APITaskManager.Repository.Interfaces;
using APITaskManager.Services.Interfaces;
using System.Threading.Tasks;

namespace APITaskManager.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<Domain.Task> CreateTaskAsync(Domain.Task taskDto)
        {
            var tasks = await _taskRepository.GetTasksByProjectIdAsync(taskDto.ProjectId);
            if (tasks.Count() >= 20)
            {
                throw new InvalidOperationException("O limite de tarefas por projeto foi atingido.");
            }

            taskDto.Status = Utils.TaskStatus.Pending;
              
            await _taskRepository.AddAsync(taskDto);
            await _taskRepository.SaveChangesAsync();

            return taskDto;
        }

        public async Task<bool> DeleteTaskAsync(int taskId)
        {
            var task = await _taskRepository.GetByIdAsync(taskId);
            if (task == null)
            {
                throw new KeyNotFoundException("Tarefa não encontrada.");
            }

            _taskRepository.Delete(task);
            await _taskRepository.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Domain.Task>> GetTasksByProjectAsync(int projectId)
        {
            return await _taskRepository.GetTasksByProjectIdAsync(projectId);
        }

        public async Task<Domain.Task> UpdateTaskAsync(Domain.Task taskUpdated)
        {
            var task = await _taskRepository.GetByIdAsync(taskUpdated.Id);
            if (task == null)
            {
                throw new KeyNotFoundException("Tarefa não encontrada.");
            }

            var history = new TaskHistory
            {
                TaskId = task.Id,
                ChangeDescription = $"Status alterado para {taskUpdated.Status.ToString()}, Título ou Descrição atualizados",
                ChangeDate = DateTime.UtcNow,
                CreatorUserId = taskUpdated.CreatorUserID
            };
            task.TaskHistories.Add(history);
            
            _taskRepository.Update(task);
            await _taskRepository.SaveChangesAsync();

            return task;
        }
    }
}
