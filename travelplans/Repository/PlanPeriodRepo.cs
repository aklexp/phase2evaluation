using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using travelplans.Models;

namespace travelplans.Repository
{
    public class PlanPeriodRepo : IPlanPeriodRepo
    {
        // data fields
        private readonly phase2Context _context;

        // default constructor
        public PlanPeriodRepo(phase2Context context)
        {
            _context = context;
        }
        //Add Plan Period 
        public async Task<int> AddPlanPeriod(Planperiod planperiod)
        {
            if (_context != null)
            {
                await _context.Planperiods.AddAsync(planperiod);
                await _context.SaveChangesAsync(); // commit transaction
                return planperiod.PeriodId;
            }
            return 0;
        }

        // Delete Plan Period
        public async Task<int> DeletePlanPeriodById(int? id)
        {
            int result = 0;
            if (_context != null)
            {
                var planperiod = await _context.Planperiods.FirstOrDefaultAsync(planperiod => planperiod.PeriodId == id);
                if (planperiod != null)
                {
                    // performing delete
                    _context.Planperiods.Remove(planperiod);
                    result = await _context.SaveChangesAsync(); // commit
                    return result;
                }
            }
            return result;
        }

        // Get all Plan Periods
        public async Task<List<Planperiod>> GetAllPlanPeriods()
        {
            if (_context != null)
            {
                return await _context.Planperiods.ToListAsync();
            }
            return null;
        }

        // Update plan Period

        public async Task UpdatePlanPeriod(Planperiod planperiod)
        {
            if (_context != null)
            {
                _context.Entry(planperiod).State = EntityState.Modified;
                _context.Planperiods.Update(planperiod);
                await _context.SaveChangesAsync();
            }
        }
    }
}
