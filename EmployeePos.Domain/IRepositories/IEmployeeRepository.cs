using EmployeePos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePos.Domain.IRepositories
{
   public interface IEmployeeRepository
    {
        Task<Employee> GetByIdAsync(Guid id); 
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<Employee> AddAsync(Employee employee);
       // Task <bool> AddEmployeeWithProject (Employee employee, Project project);
        Task<Employee> UpdateAsync(Employee employee);
        Task<bool> DeleteByIdAsync(Guid id);
    }
}
