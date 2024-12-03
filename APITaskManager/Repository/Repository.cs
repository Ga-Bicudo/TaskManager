﻿using APITaskManager.Data;
using APITaskManager.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace APITaskManager.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public readonly TaskManagerDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(TaskManagerDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}