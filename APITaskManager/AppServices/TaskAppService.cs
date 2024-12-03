using APITaskManager.AppServices.Interfaces;
using APITaskManager.Services;
using APITaskManager.Services.Interfaces;
using APITaskManager.ViewModels;
using AutoMapper;

namespace APITaskManager.AppServices
{
    public class TaskAppService : ITaskAppService
    {
        private readonly ITaskService _taskService;
        private readonly IMapper _mapper;

        public TaskAppService(ITaskService taskService, IMapper mapper)
        {
            _taskService = taskService;
            _mapper = mapper;
        }

        public async Task<TaskViewModel> CreateTaskAsync(TaskViewModel dto)
        {
            return _mapper.Map<TaskViewModel>(await _taskService.CreateTaskAsync(_mapper.Map<Domain.Task>(dto)));
        }

        public async Task<bool> DeleteTaskAsync(int taskId)
        {
            return await _taskService.DeleteTaskAsync(taskId);
        }

        public async Task<IEnumerable<TaskViewModel>> GetTasksByProjectAsync(int projectId)
        {
            return _mapper.Map<IEnumerable<TaskViewModel>>(await _taskService.GetTasksByProjectAsync(projectId));
        }

        public async Task<TaskViewModel> UpdateTaskAsync( TaskViewModel dto)
        {
            return _mapper.Map<TaskViewModel>(await _taskService.UpdateTaskAsync(_mapper.Map<Domain.Task>(dto)));
        }
    }
}
