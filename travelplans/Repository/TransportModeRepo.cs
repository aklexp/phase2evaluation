using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using travelplans.Models;

namespace travelplans.Repository
{
    public class TransportModeRepo : ITransportMode
    {
        // data fields
        private readonly phase2Context _context;

        // default constructor
        public TransportModeRepo(phase2Context context)
        {
            _context = context;
        }
        // Add Transport Mode
        public async Task<int> AddMode(Transpordmode mode)
        {
            if (_context != null)
            {
                await _context.Transpordmodes.AddAsync(mode);
                await _context.SaveChangesAsync(); // commit transaction
                return mode.Tid;
            }
            return 0;
        }

        // Delete transport mode
        public async Task<int> DeleteMOdeById(int? id)
        {
            int result = 0;
            if (_context != null)
            {
                var TransportMode = await _context.Transpordmodes.FirstOrDefaultAsync(TransportMode => TransportMode.Tid == id);
                if (TransportMode != null)
                {
                    // performing delete
                    _context.Transpordmodes.Remove(TransportMode);
                    result = await _context.SaveChangesAsync(); // commit
                    return result;
                }
            }
            return result;
        }

        // Get all transport mode
        public async Task<List<Transpordmode>> GetAllModes()
        {
            if (_context != null)
            {
                return await _context.Transpordmodes.ToListAsync();
            }
            return null;
        }

        // Update Transport Mode
        public async Task UpdateMode(Transpordmode mode)
        {
            if (_context != null)
            {
                _context.Entry(mode).State = EntityState.Modified;
                _context.Transpordmodes.Update(mode);
                await _context.SaveChangesAsync();
            }
        }
    }
}
