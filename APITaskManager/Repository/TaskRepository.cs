using APITaskManager.Data;
using APITaskManager.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace APITaskManager.Repository
{
    public class TaskRepository : Repository<Domain.Task>, ITaskRepository
    {
        public TaskRepository(TaskManagerDbContext context) : base(context) { }

        public async Task<IEnumerable<Domain.Task>> GetTasksByProjectIdAsync(int projectId)
        {
            return await _context.Task.Where(x => x.ProjectId == projectId).ToListAsync();
        }
    }
}
