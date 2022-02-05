using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using travelplans.Repository;

namespace travelplans.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViemModelController : ControllerBase
    {
        // data fields
        private readonly IViewmodelrepo _iviem;

        // default constructor
        public ViemModelController(IViewmodelrepo iviem)
        {
            _iviem = iviem;
        }

        [HttpGet("plansnotexceed2days")]
        [Authorize]
        public async Task<IActionResult> GetPlans()
        {
            try
            {
                var plans = await _iviem.GetAllPlanViewModel();
                if (plans == null)
                {
                    return NotFound();
                }
                return Ok(plans);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet("plandetails")]
        public async Task<IActionResult> GetPlanDetails()
        {
            try
            {
                var planDetails= await _iviem.GetAllPlanDetails();
                if (planDetails == null)
                {
                    return NotFound();
                }
                return Ok(planDetails);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
