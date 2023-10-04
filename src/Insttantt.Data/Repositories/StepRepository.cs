using Insttantt.Data.DataAccess;
using Insttantt.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insttantt.Data.Repositories
{
    public interface IStepRepository
    {
        Task<Step> GetByIdAsync(int id);
        Task<IEnumerable<Step>> GetAllAsync();
        Task AddAsync(Step step);
        Task UpdateAsync(Step step);
        Task DeleteAsync(int id);
    }

    public class StepRepository : IStepRepository
    {
        private readonly InsttanttDataDBContext _context;
        private readonly DbSet<Step> _steps;

        public StepRepository(InsttanttDataDBContext context)
        {
            _context = context;
            _steps = context.Steps;
        }

        public async Task<Step> GetByIdAsync(int id)
        {
            try
            {
                return await _steps.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<IEnumerable<Step>> GetAllAsync()
        {
            try
            {
                return await _steps.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task AddAsync(Step step)
        {
            try
            {
                await _steps.AddAsync(step);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task UpdateAsync(Step step)
        {
            try
            {
                _steps.Update(step);
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
                var step = await GetByIdAsync(id);
                if (step != null)
                {
                    _steps.Remove(step);
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
