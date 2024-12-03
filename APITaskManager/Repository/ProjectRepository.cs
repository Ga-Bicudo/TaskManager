using APITaskManager.Data;
using APITaskManager.Domain;
using APITaskManager.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace APITaskManager.Repository
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        public ProjectRepository(TaskManagerDbContext context) : base(context) { }

        public async Task<IEnumerable<Project>> GetProjectsByUserIdAsync()
        {
            return await _context.Project.ToListAsync();
        }
    }
}
