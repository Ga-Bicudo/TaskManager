namespace APITaskManager.Repository.Interfaces
{
    public interface ITaskRepository : IRepository<Domain.Task>
    {
        Task<IEnumerable<Domain.Task>> GetTasksByProjectIdAsync(int projectId);
    }
}
