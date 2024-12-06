using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeePos.Domain.Models;

namespace EmployeePos.Domain.IRepositories
{
    public interface IPositionRepository
    {
        Task<Position> GetPositionByIdAsync(Guid id);
        Task<IReadOnlyList<Position>> GetAllPositionAsync();
        Task<Position> AddPositionAsync(Position position);
        Task<Position> UpdatePositionAsync(Position position);
        Task<bool> DeletePositionByIdAsync(Guid id);
        Task<IReadOnlyList<Position>> GetPositionHierarchyAsync();
    }
}
