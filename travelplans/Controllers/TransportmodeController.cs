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
    public class TransportmodeController : ControllerBase
    {
        // data fields
        private readonly ITransportMode _mode;

        // default constructor
        public TransportmodeController(ITransportMode mode)
        {
            _mode = mode;
        }

        #region Get all Transport modes
        //https://localhost:44317/api/Transportmode
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transpordmode>>> GetModeAll()
        {
            return await _mode.GetAllModes();
        }
        #endregion

        #region Add a Transport mode
        [HttpPost]
        public async Task<IActionResult> AddDestination([FromBody] Transpordmode mode)
        {
            // check validation of the body
            if (ModelState.IsValid)
            {
                try
                {
                    var modeId = await _mode.AddMode(mode);
                    if (modeId > 0)
                    {
                        return Ok(modeId);
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

        #region Update Transport Mode
        [HttpPut]
        public async Task<IActionResult> UpdateMode([FromBody] Transpordmode mode)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _mode.UpdateMode(mode);
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

        #region Delete transport Mode
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletemodeByID(int? id)
        {
            int result = 0;
            if (id == null)
            {
                return BadRequest();
            }
            try
            {
                result = await _mode.DeleteMOdeById(id);
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
