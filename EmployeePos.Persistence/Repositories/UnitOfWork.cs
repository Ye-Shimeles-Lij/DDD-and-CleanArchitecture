using EmployeePos.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePos.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IEmployeeRepository Employees {  get; private set; }

        private readonly PositionDbContext _context;

        public UnitOfWork (IEmployeeRepository employeeRepository , PositionDbContext context)
        {
           Employees = employeeRepository;
            _context = context;
        }
        public async Task CommitAsync() 
        { 
            await _context.SaveChangesAsync(); 
        }
        public void Dispose() 
        {
            _context.Dispose(); 
        }
    }
}
