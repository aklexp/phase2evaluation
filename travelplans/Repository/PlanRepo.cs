using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using travelplans.Models;

namespace travelplans.Repository
{
    public class PlanRepo : IPlanRepo
    {
        // data fields
        private readonly phase2Context _context;

        // default constructor
        public PlanRepo(phase2Context context)
        {
            _context = context;
        }
        // Add plan 
        public async Task<int> AddPlans(Plan plan)
        {
            if (_context != null)
            {
                await _context.Plans.AddAsync(plan);
                await _context.SaveChangesAsync(); // commit transaction
                return plan.Plid;
            }
            return 0;
        }

        // Delete plan
        public async Task<int> DeletePlanById(int? id)
        {
            int result = 0;
            if (_context != null)
            {
                var plan = await _context.Plans.FirstOrDefaultAsync(plan => plan.Plid == id);
                if (plan != null)
                {
                    // performing delete
                    _context.Plans.Remove(plan);
                    result = await _context.SaveChangesAsync(); // commit
                    return result;
                }
            }
            return result;
        }

        // Get all Plans
        public async Task<List<Plan>> GetAllPlans()
        {
            if (_context != null)
            {
                return await _context.Plans.ToListAsync();
            }
            return null;
        }

        //Update Plan 

        public async Task UpdatePlan(Plan plan)
        {
            if (_context != null)
            {
                _context.Entry(plan).State = EntityState.Modified;
                _context.Plans.Update(plan);
                await _context.SaveChangesAsync();
            }
        }
    }
}
