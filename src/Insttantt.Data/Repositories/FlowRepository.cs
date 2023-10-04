using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insttantt.Data.Repositories
{
    using Insttantt.Data.DataAccess;
    using Insttantt.Data.Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    namespace ProjectName.Data.Repositories
    {
        public interface IFlowRepository
        {
            Task<Flow> GetByIdAsync(int id);
            Task<IEnumerable<Flow>> GetAllAsync();
            Task AddAsync(Flow flow);
            Task UpdateAsync(Flow flow);
            Task DeleteAsync(int id);
        }

        public class FlowRepository : IFlowRepository
        {
            private readonly InsttanttDataDBContext _context;
            private readonly DbSet<Flow> _flows;

            public FlowRepository(InsttanttDataDBContext context)
            {
                _context = context;
                _flows = context.Flows;
            }

            public async Task<Flow> GetByIdAsync(int id)
            {
                try
                {
                    return await _flows.FindAsync(id);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

            public async Task<IEnumerable<Flow>> GetAllAsync()
            {
                try
                {
                    return await _flows.ToListAsync();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

            public async Task AddAsync(Flow flow)
            {
                try
                {
                    await _flows.AddAsync(flow);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

            public async Task UpdateAsync(Flow flow)
            {
                try
                {
                    _flows.Update(flow);
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
                    var flow = await GetByIdAsync(id);
                    if (flow != null)
                    {
                        _flows.Remove(flow);
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
}
