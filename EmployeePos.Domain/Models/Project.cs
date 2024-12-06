using EmployeePos.Domain.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePos.Domain.Models
{
    public class Project : IEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; } 
       
        public Project(string title, string description)
        {
            Title = title;  
            Description = description;
           

        }
        public void SetEmployee(Guid employeeId)
        {
            EmployeeId = employeeId;
        }
    }
}
