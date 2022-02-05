using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using travelplans.Models;

namespace travelplans.Repository
{
    public interface IPlanPeriodRepo
    {
        // Get all Plan Period
        Task<List<Planperiod>> GetAllPlanPeriods(); // Asynchronous

        // add a Planperiod --insert

        Task<int> AddPlanPeriod(Planperiod planperiod);

        // update a Planperiod

        Task UpdatePlanPeriod(Planperiod planperiod);

        // Delete a Planperiod

        Task<int> DeletePlanPeriodById(int? id);
    }
}
