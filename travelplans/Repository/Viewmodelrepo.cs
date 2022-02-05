using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using travelplans.Models;
using travelplans.ViemModel;

namespace travelplans.Repository
{
    public class Viewmodelrepo : IViewmodelrepo
    {
        // data fields
        private readonly phase2Context _context;

        // default constructor
        // constructor based dependency injection
        public Viewmodelrepo(phase2Context context)
        {
            _context = context;
        }

        // period <= 2
        public async Task<List<PlanTwoDays>> GetAllPlanViewModel()
        {
            if (_context != null)
            {
                return await (
                    from Plan in _context.Plans
                    from period in _context.Planperiods
                    where Plan.Plid == period.Plid
                    && period.Noofdays <= 2
                    select new PlanTwoDays
                    {
                        PlanName = Plan.Plname,
                        Duration = period.Noofdays
                    }
                    ).ToListAsync();
            }
            return null;
        }
        public async Task<List<PlanDetails>> GetAllPlanDetails()
        {
            if (_context != null)
            {
                return await (
                from plan in _context.Plans
                from period in _context.Planperiods
                from price in _context.Planprices
                from mode in _context.Transpordmodes
                where plan.Plid == period.Plid && price.Plid == plan.Plid
                && mode.Plid == plan.Plid
                select new PlanDetails
                {
                    Name = plan.Plname,
                    Price = price.Amount,
                    Period = period.Noofdays,
                    Mode = mode.Tname
                }
                ).ToListAsync();
            }
            return null;
            
            
        }
    }
}
