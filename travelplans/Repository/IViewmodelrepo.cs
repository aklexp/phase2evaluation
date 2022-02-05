using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using travelplans.ViemModel;

namespace travelplans.Repository
{
    public interface IViewmodelrepo
    {
        // get all post with duration <=2
        Task<List<PlanTwoDays>> GetAllPlanViewModel();

        // Get Plan Details
        Task<List<PlanDetails>> GetAllPlanDetails();
    }
}
