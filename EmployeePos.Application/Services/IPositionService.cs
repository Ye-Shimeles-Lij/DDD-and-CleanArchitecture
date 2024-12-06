using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeePos.Application.DTOs;

namespace EmployeePos.Application.Service
{
    public interface IPositionService
    {
        Task<PositionDto> GetPositionByIdAsync(int id);
        Task<IReadOnlyList<PositionDto>> GetAllPositionAsync();
        Task<PositionDto> AddPositionAsync(PositionDto positionDto);
        Task<PositionDto> UpdatePositionAsync(PositionDto positionDto);
        Task<bool> DeletePositionByIdAsync(int id);
        Task<IReadOnlyList<PositionDto>> GetPositionHierarchyAsync();
    }
}
