using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using travelplans.Models;

namespace travelplans.Repository
{
    public class PlaceRepo : IPlaceRepo
    {
        // data fields
        private readonly phase2Context _context;

        // default constructor
        public PlaceRepo(phase2Context context)
        {
            _context = context;
        }

        // Add place
        public async Task<int> AddPlaces(Place place)
        {
            if (_context != null)
            {
                await _context.Places.AddAsync(place);
                await _context.SaveChangesAsync(); // commit transaction
                return place.Pid;
            }
            return 0;

        }

        // Delete
        public async Task<int> DeletePlaceById(int? id)
        {
            int result = 0;
            if (_context != null)
            {
                var place = await _context.Places.FirstOrDefaultAsync(place => place.Pid == id);
                if (place != null)
                {
                    // performing delete
                    _context.Places.Remove(place);
                    result = await _context.SaveChangesAsync(); // commit
                    return result;
                }
            }
            return result;
        }

        // Get

        public async Task<List<Place>> GetAllPlaces()
        {
            if (_context != null)
            {
                return await _context.Places.ToListAsync();
            }
            return null;
        }

        // Update
        public async Task UpdatePlaces(Place place)
        {
            if (_context != null)
            {
                _context.Entry(place).State = EntityState.Modified;
                _context.Places.Update(place);
                await _context.SaveChangesAsync();
            }
        }
    }
}
