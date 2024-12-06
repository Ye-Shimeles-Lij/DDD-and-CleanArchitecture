using MediatR;
using EmployeePos.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using EmployeePos.Domain.IRepositories;
using EmployeePos.Domain.Models;
using System.Transactions;
using EmployeePos.Persistence;

namespace EmployeePos.Application.Employees.Commands
{
    public class AddEmployeeWithProjectcommand : IRequest<bool>
    {
        public Employee Employee { get; set; }
        public Project Project { get; set; }
        public AddEmployeeWithProjectcommand(Employee employee, Project project)
        {
            Employee = employee;
            Project = project;
        }
    }
    public class AddEmployeeWithProjectHandler : IRequestHandler<AddEmployeeWithProjectcommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PositionDbContext _positionDbContext;
        public AddEmployeeWithProjectHandler(IUnitOfWork unitOfWork, PositionDbContext positionDbContext)
        {
            _unitOfWork = unitOfWork;
            _positionDbContext = positionDbContext;
        }
        public async Task<bool> Handle(AddEmployeeWithProjectcommand command, CancellationToken cancellationToken)
        {
           var transaction = _positionDbContext.Database.BeginTransaction();
            try
            {
              //  Transaction.begin();
                //await _unitOfWork.Po.AddAsync(command.Employee);
                //await _unitOfWork.CommitAsync();
                //await _unitOfWork.Em.AddAsync(command.Employee);
                //await _unitOfWork.CommitAsync();

                command.Employee.AddAsync(command.Project);
                await _positionDbContext.SaveChangesAsync();
                await _positionDbContext.Employees.AddAsync(command.Employee);
                await _positionDbContext.SaveChangesAsync();
                transaction.Commit();
                return true;
            }
            catch (Exception )
            {
               transaction.Rollback();
                return false;
            }
        }


    }
}



