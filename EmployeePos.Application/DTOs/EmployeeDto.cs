using EmployeePos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeePos.Domain.ValueObjects;

namespace EmployeePos.Application.DTOs
{
    public class EmployeeDto
    {
        public Guid Id { get; set; }
        public FullName FullName { get; set; }
        public string? Email { get; set; }
        private string? _FirstName { get; set; }
        private string FirstName 
        { 
            get => _FirstName; 
            set
            {
                _FirstName = value;
                if (FullName == null) FullName = new FullName();
                FullName.FirstName = _FirstName;
            }
        }
        private string? _LastName { get; set; }
        private string LastName
        {
            get => _LastName;
            set
            {
                _LastName = value;
                if (FullName == null) FullName = new FullName();
                FullName.LastName = _LastName;
            }
        }

    }
    public class GetEmployeeDto : EmployeeDto
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
