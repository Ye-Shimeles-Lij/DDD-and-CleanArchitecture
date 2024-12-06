using EmployeePos.Domain.Generics;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePos.Domain.ValueObjects
{
    public class FullName : IValueObject
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public FullName()
        {
            
        }
        public FullName(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
  
}
