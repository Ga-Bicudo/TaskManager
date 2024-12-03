using APITaskManager.Domain;

namespace APITaskManager.Repository.Interfaces
{
    public interface IProjectRepository: IRepository<Project>
    {
        Task<IEnumerable<Project>> GetProjectsByUserIdAsync();
    }
}
