using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeePos.Application.Employees.Commands;
using FluentValidation;

namespace EmployeePos.Application.Employees.Validators
{
    public class AddEmployeeValidator : AbstractValidator<AddEmployeeCommand>
    {
        public AddEmployeeValidator()
        {
            RuleFor(e => e.FirstName).NotEmpty();
            RuleFor(e => e.LastName).NotEmpty();
            RuleFor(e => e.Email).EmailAddress().NotEmpty();
        }

    }
}
