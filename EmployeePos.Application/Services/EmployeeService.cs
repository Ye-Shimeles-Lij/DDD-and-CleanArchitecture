using EmployeePos.Application.DTOs;
using EmployeePos.Domain.IRepositories;
using EmployeePos.Persistence.Repositories;
using EmployeePos.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePos.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeRepository _repo;
        public EmployeeService ( EmployeeRepository repo)
        {
            _repo = repo;
        }
        public async Task<EmployeeDto> GetEmployeeByIdAsync(Guid id)
        {
            var employee = await _repo.GetByIdAsync(id);
            if (employee == null)
            {
                throw new Exception(" no employees found");
            }
            return new EmployeeDto
            {
                Id = employee.Id,
                FullName = employee.FullName,
                Email = employee.Email
            };
        }
        public async Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync() 
        { 
            var employees = await _repo.GetAllAsync(); 
            return employees.Select(employee => new EmployeeDto 
            { 
                Id = employee.Id,
               FullName = employee.FullName,
                Email = employee.Email 
            });
        }

    }
}


