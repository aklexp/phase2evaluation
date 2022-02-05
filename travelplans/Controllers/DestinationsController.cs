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
    public class DestinationsController : ControllerBase
    {
        // data fields
        private readonly IDestinationRepo _idestination;

        // default constructor
        public DestinationsController(IDestinationRepo idestination)
        {
            _idestination = idestination;
        }

        #region Get all Destinations
        //https://localhost:44317/api/Destinations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Destination>>> GetDestinationsAll()
        {
            return await _idestination.GetAllDestinations();
        }
        #endregion

        #region Add a Destination
        [HttpPost]
        public async Task<IActionResult> AddDestination([FromBody]Destination destination)
        {
            // check validation of the body
            if (ModelState.IsValid)
            {
                try
                {
                    var destinationId = await _idestination.AddDestination(destination);
                    if (destinationId > 0)
                    {
                        return Ok(destinationId);
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

        #region Update Destination
        [HttpPut]
        public async Task<IActionResult> UpdateDestination([FromBody] Destination destination)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _idestination.UpdateDestination(destination);
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

        #region Delete Destination
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDestinationByID(int? id)
        {
            int result = 0;
            if (id == null)
            {
                return BadRequest();
            }
            try
            {
                result = await _idestination.DeleteDestinationById(id);
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
