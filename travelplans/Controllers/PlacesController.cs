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
    public class PlacesController : ControllerBase
    {
        // data fields
        private readonly IPlaceRepo _iplace;

        // default constructor
        public PlacesController(IPlaceRepo iplace)
        {
            _iplace = iplace;
        }

        #region Get all Places
        //https://localhost:44317/api/Places
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Place>>> GetPlacesAll()
        {
            return await _iplace.GetAllPlaces();
        }
        #endregion

        #region Add a Place
        [HttpPost]
        public async Task<IActionResult> AddPlace([FromBody] Place place)
        {
            // check validation of the body
            if (ModelState.IsValid)
            {
                try
                {
                    var placeId = await _iplace.AddPlaces(place);
                    if (placeId > 0)
                    {
                        return Ok(placeId);
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

        #region Update Place
        [HttpPut]
        public async Task<IActionResult> UpdatePlace([FromBody] Place place)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _iplace.UpdatePlaces(place);
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

        #region Delete Place
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlaceByID(int? id)
        {
            int result = 0;
            if (id == null)
            {
                return BadRequest();
            }
            try
            {
                result = await _iplace.DeletePlaceById(id);
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
