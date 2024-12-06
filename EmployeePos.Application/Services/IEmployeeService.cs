using EmployeePos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeePos.Application.DTOs;

namespace EmployeePos.Application.Services
{
    public interface IEmployeeService
    {
        Task<EmployeeDto> GetEmployeeByIdAsync(Guid empid);
        Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync();
       /* Task<EmployeeDto> AddEmployeeAsync(EmployeeDto employeedto);
        Task<EmployeeDto> UpdateEmployeeAsync(EmployeeDto employeedto);
        Task<bool> DeleteEmployeeByIdAsync(Guid empid);*/
    }
}
