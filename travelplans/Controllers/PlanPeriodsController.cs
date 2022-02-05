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
    public class PlanPeriodsController : ControllerBase
    {
        // data fields
        private readonly IPlanPeriodRepo _iplan;

        // default constructor
        public PlanPeriodsController(IPlanPeriodRepo iplan)
        {
            _iplan = iplan;
        }

        #region Get all Plan Periods
        //https://localhost:44317/api/PlanPeriods
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Planperiod>>> GetPlanPeriodsAll()
        {
            return await _iplan.GetAllPlanPeriods();
        }
        #endregion

        #region Add a Plan period
        [HttpPost]
        public async Task<IActionResult> AddPlanPeriod([FromBody] Planperiod plan)
        {
            // check validation of the body
            if (ModelState.IsValid)
            {
                try
                {
                    var planId = await _iplan.AddPlanPeriod(plan);
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

        #region Update Plan period
        [HttpPut]
        public async Task<IActionResult> UpdatePlanPeriod([FromBody] Planperiod plan)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _iplan.UpdatePlanPeriod(plan);
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

        #region Delete plan period
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlanPeriodByID(int? id)
        {
            int result = 0;
            if (id == null)
            {
                return BadRequest();
            }
            try
            {
                result = await _iplan.DeletePlanPeriodById(id);
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
