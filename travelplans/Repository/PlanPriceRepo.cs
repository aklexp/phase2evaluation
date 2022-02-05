using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using travelplans.Models;

namespace travelplans.Repository
{
    public class PlanPriceRepo : IPlanPricerepo
    {
        // data fields
        private readonly phase2Context _context;

        // default constructor
        public PlanPriceRepo(phase2Context context)
        {
            _context = context;
        }
        
        //Add A Plan Price
        public async Task<int> AddPlanPrice(Planprice planprice)
        {
            if (_context != null)
            {
                await _context.Planprices.AddAsync(planprice);
                await _context.SaveChangesAsync(); // commit transaction
                return planprice.Ppid;
            }
            return 0;
        }

        //Delete a Plan Price 
        public async Task<int> DeletePlanPriceById(int? id)
        {
            int result = 0;
            if (_context != null)
            {
                var planprice = await _context.Planprices.FirstOrDefaultAsync(planprice => planprice.Ppid == id);
                if (planprice != null)
                {
                    // performing delete
                    _context.Planprices.Remove(planprice);
                    result = await _context.SaveChangesAsync(); // commit
                    return result;
                }
            }
            return result;
        }

        // Get all Plan Prices
        public async Task<List<Planprice>> GetAllPlanPrices()
        {
            if (_context != null)
            {
                return await _context.Planprices.ToListAsync();
            }
            return null;
        }

        // Update a Plan Price
        public async Task UpdatePlanPrice(Planprice planprice)
        {
            if (_context != null)
            {
                _context.Entry(planprice).State = EntityState.Modified;
                _context.Planprices.Update(planprice);
                await _context.SaveChangesAsync();
            }
        }
    }
}
