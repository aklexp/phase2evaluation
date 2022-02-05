using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using travelplans.Models;
using travelplans.Repository;

namespace travelplans.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlansController : ControllerBase
    {
        // data fields
        private readonly IPlanRepo _iplan;

        // default constructor
        public PlansController(IPlanRepo iplan)
        {
            _iplan = iplan;
        }

        #region Get all Plans
        //https://localhost:44317/api/Plans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Plan>>> GetPlansAll()
        {
            return await _iplan.GetAllPlans();
        }
        #endregion

        #region Add a Plan
        [HttpPost]
        public async Task<IActionResult> AddPlan([FromBody] Plan plan)
        {
            // check validation of the body
            if (ModelState.IsValid)
            {
                try
                {
                    var planId = await _iplan.AddPlans(plan);
                    if (planId > 0)
                    {
                        return Ok(planId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        #endregion

        #region Update Plan
        [HttpPut]
        public async Task<IActionResult> UpdatePlan([FromBody] Plan plan)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _iplan.UpdatePlan(plan);
                    return Ok();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion

        #region Delete plan
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlanByID(int? id)
        {
            int result = 0;
            if (id == null)
            {
                return BadRequest();
            }
            try
            {
                result = await _iplan.DeletePlanById(id);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion
    }
}
