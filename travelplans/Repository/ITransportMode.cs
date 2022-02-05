using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using travelplans.Models;

namespace travelplans.Repository
{
    public interface ITransportMode
    {
        // Get all transport Mode
        Task<List<Transpordmode>> GetAllModes(); // Asynchronous

        // add a transport Mode --insert

        Task<int> AddMode(Transpordmode mode);

        // update a transport Mode

        Task UpdateMode(Transpordmode mode);

        // Delete a transport Mode

        Task<int> DeleteMOdeById(int? id);
    }
}
