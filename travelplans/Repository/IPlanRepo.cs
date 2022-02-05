using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using travelplans.Models;

namespace travelplans.Repository
{
    public interface IPlanRepo
    {
        // Get all Plan
        Task<List<Plan>> GetAllPlans(); // Asynchronous

        // add a Plan --insert

        Task<int> AddPlans(Plan plan);

        // update a Plan

        Task UpdatePlan(Plan plan);

        // Delete a Plan

        Task<int> DeletePlanById(int? id);
    }
}
