﻿using ListApi.DAL.Data;
using ListApi.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public class GenericRepository<T> where T : Entity
    {
        protected DatabaseContext _context;
        protected DbSet<T> _entity;

        public GenericRepository(DatabaseContext context)
        {
            _context = context;
            _entity = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entity.ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _entity.FindAsync(id);
        }

        public async Task CreateAsync(T entity)
        {
            await _entity.AddAsync(entity);
        }

        public void Edit(T entity)
        {
            _entity.Update(entity);
        }

        public void Delete(T entity)
        {
            _entity.Remove(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
