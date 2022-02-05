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
    public class PlanPriceController : ControllerBase
    {
        // data fields
        private readonly IPlanPricerepo _iplan;

        // default constructor
        public PlanPriceController(IPlanPricerepo iplan)
        {
            _iplan = iplan;
        }

        #region Get all Plan Prices
        //https://localhost:44317/api/PlanPrice
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Planprice>>> GetPlanPricesAll()
        {
            return await _iplan.GetAllPlanPrices();
        }
        #endregion

        #region Add a Plan price
        [HttpPost]
        public async Task<IActionResult> AddPlanPeriod([FromBody] Planprice plan)
        {
            // check validation of the body
            if (ModelState.IsValid)
            {
                try
                {
                    var planId = await _iplan.AddPlanPrice(plan);
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

        #region Update Plan price
        [HttpPut]
        public async Task<IActionResult> UpdatePlanPriceById([FromBody] Planprice plan)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _iplan.UpdatePlanPrice(plan);
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

        #region Delete plan price
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlanPriceByID(int? id)
        {
            int result = 0;
            if (id == null)
            {
                return BadRequest();
            }
            try
            {
                result = await _iplan.DeletePlanPriceById(id);
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
