using System;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeePos.Application.Position.Command;

namespace EmployeePos.Application.Position.Validator
{
    public class AddPositionValidator : AbstractValidator<AddPositionCommand>
    {
        public AddPositionValidator()
        {
            RuleFor(command => command.Name)
                .NotEmpty().WithMessage("Position Name can not be empty.");
        }
    }
}


