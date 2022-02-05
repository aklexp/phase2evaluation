using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using travelplans.Models;

namespace travelplans.Repository
{
    public class DestinationRepo : IDestinationRepo
    {
        // data fields
        private readonly phase2Context _context;

        // default constructor
        public DestinationRepo(phase2Context context)
        {
            _context = context;
        }

        #region Get all Destinations
        public async Task<List<Destination>> GetAllDestinations()
        {
            if (_context != null)
            {
                return await _context.Destination.ToListAsync();
            }
            return null;
        }
        #endregion

        #region Add Destination
        public async Task<int> AddDestination(Destination destination)
        {
            if (_context != null)
            {
                await _context.Destination.AddAsync(destination);
                await _context.SaveChangesAsync(); // commit transaction
                return destination.Did;
            }
            return 0;
        }
        #endregion

        #region Update Destination
        public async Task UpdateDestination(Destination destination)
        {
            if (_context != null)
            {
                _context.Entry(destination).State = EntityState.Modified;
                _context.Destination.Update(destination);
                await _context.SaveChangesAsync();
            }
        }
        #endregion

        #region Delete a Destination
        public async Task<int> DeleteDestinationById(int? id)
        {
            int result = 0;
            if (_context != null)
            {
                var dest = await _context.Destination.FirstOrDefaultAsync(dest => dest.Did == id);
                if (dest != null)
                {
                    // performing delete
                    _context.Destination.Remove(dest);
                    result = await _context.SaveChangesAsync(); // commit
                    return result;
                }
            }
            return result;
        }
        #endregion
    }
}
