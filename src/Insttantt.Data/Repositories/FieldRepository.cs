using Insttantt.Data.DataAccess;
using Insttantt.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Insttantt.Data.Repositories
{
    public interface IFieldRepository
    {
        Task<Field> GetByIdAsync(int id);
        Task<IEnumerable<Field>> GetAllAsync();
        Task AddAsync(Field field);
        Task UpdateAsync(Field field);
        Task DeleteAsync(int id);
    }

    public class FieldRepository : IFieldRepository
    {
        private readonly InsttanttDataDBContext _context;
        private readonly DbSet<Field> _fields;

        public FieldRepository(InsttanttDataDBContext context)
        {
            _context = context;
            _fields = context.Fields;
        }

        public async Task<Field> GetByIdAsync(int id)
        {
            try
            {
                return await _fields.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<IEnumerable<Field>> GetAllAsync()
        {
            try
            {
                return await _fields.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task AddAsync(Field field)
        {
            try
            {
                await _fields.AddAsync(field);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task UpdateAsync(Field field)
        {
            try
            {
                _fields.Update(field);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var field = await GetByIdAsync(id);
                if (field != null)
                {
                    _fields.Remove(field);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}