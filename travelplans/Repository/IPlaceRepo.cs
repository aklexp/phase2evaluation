using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using travelplans.Models;

namespace travelplans.Repository
{
    public interface IPlaceRepo
    {

        // Get all Places
        Task<List<Place>> GetAllPlaces(); // Asynchronous

        // add a Place --insert

        Task<int> AddPlaces(Place place);

        // update a Place

        Task UpdatePlaces(Place place);

        // Delete a Place

        Task<int> DeletePlaceById(int? id);
    }
}
