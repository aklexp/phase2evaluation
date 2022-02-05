using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using travelplans.Models;

namespace travelplans.Repository
{
    public interface IDestinationRepo
    {
        // get all Destinations
        // asynchronous manner -Async - await - Promise
        Task<List<Destination>> GetAllDestinations(); // Asynchronous

        // add a Destination --insert

        Task<int> AddDestination(Destination destination);

        // update a Destination

        Task UpdateDestination(Destination destination);
        
        // Delete a Destination

        Task<int> DeleteDestinationById(int? id);
    }
}
