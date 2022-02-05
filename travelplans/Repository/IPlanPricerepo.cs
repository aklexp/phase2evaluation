using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using travelplans.Models;

namespace travelplans.Repository
{
    public interface IPlanPricerepo
    {
        // Get all plan price
        Task<List<Planprice>> GetAllPlanPrices(); // Asynchronous

        // add a Planperiod --insert

        Task<int> AddPlanPrice(Planprice planprice);

        // update a plan price

        Task UpdatePlanPrice(Planprice planprice);

        // Delete a plan price

        Task<int> DeletePlanPriceById(int? id);
    }
}
