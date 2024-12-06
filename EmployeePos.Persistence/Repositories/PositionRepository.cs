using EmployeePos.Domain.IRepositories;
using EmployeePos.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePos.Persistence.Repositories
{
    public class PositionRepository : IPositionRepository
    {
        private readonly PositionDbContext _context;

        public PositionRepository(PositionDbContext context)
        {
            _context = context;
        }
        public async Task<Position> GetPositionByIdAsync(Guid id)
        {
            return await _context.Positions.Include(p => p.Children).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IReadOnlyList<Position>> GetAllPositionAsync()
        {
            return await _context.Positions.Include(p => p.Children).ToListAsync();

        }

        async Task<Position> IPositionRepository.AddPositionAsync(Position position)
        {
            _context.Positions.Add(position);
            await _context.SaveChangesAsync();
            return position;

        }
        // Check if a position exists by ID
        private bool PositionExists(Guid id)
        {
            return _context.Positions.Any(e => e.Id == id);
        }
        async Task<Position> IPositionRepository.UpdatePositionAsync(Position position)
        {
            _context.Entry(position).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PositionExists(position.Id))
                {
                    return position ?? null;
                }
                else
                {
                    throw;
                }
            }
            return position;
        }

        public async Task<bool> DeletePositionByIdAsync(Guid id)
        {
            var position = await _context.Positions.FindAsync(id);
            if (position == null)
            {
                return false;
            }

            _context.Positions.Remove(position);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IReadOnlyList<Position>> GetPositionHierarchyAsync()
        {
            var rootPositions = await _context.Positions
               .Include(p => p.Children)
               .Where(p => p.ParentId == null)
               .ToListAsync();

            return rootPositions;
        }

    }

}
