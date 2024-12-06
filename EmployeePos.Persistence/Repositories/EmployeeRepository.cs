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
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly PositionDbContext _context;

        public EmployeeRepository(PositionDbContext context)
        {
            _context = context;
        }
        public async Task<Employee> GetByIdAsync(Guid id)
        {
           return await _context.Employees.Include(e => e.Projects).FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _context.Employees.ToListAsync();

        }

        async Task<Employee> IEmployeeRepository.AddAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;

        }
        
        private bool EmployeeExists(Guid id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
        async Task<Employee> IEmployeeRepository.UpdateAsync(Employee employee)
        {
            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(employee.Id))
                {
                    throw new Exception("Employee not found");
                }
                else
                {
                    throw;
                }
            }
            return employee;
        }

        public async Task<bool> DeleteByIdAsync(Guid empid)
        {
            var employee = await _context.Employees.FindAsync(empid);
            if (employee == null)
            {
                return false;
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
