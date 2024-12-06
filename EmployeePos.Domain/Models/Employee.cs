using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using EmployeePos.Domain.Generics;
using EmployeePos.Domain.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EmployeePos.Domain.Models
{
    public class Employee : IAggregate
    {
      
        public Guid Id { get; set; }
        public FullName FullName { get; set; }
        public string Email { get; set; }

        private List<Project> projects;
       
        public IReadOnlyCollection<Project> Projects => projects;
        public Employee()
        {
            FullName = new FullName();
            projects = new List<Project>();
        }
        public Employee(FullName fullname, string email) : this()
        {
            FullName = fullname ?? throw new ArgumentNullException(nameof(fullname));
            Email = email;
        }

        public void AddAsync(Project project)
        {
            projects.Add(project);
        }
        public void AddAsync(string Title, string Description)
        {
            var project=projects.FirstOrDefault(p => p.Title == Title);
            projects.Add(project);
        }
        public void DeleteAsync(Guid Id)
        {
            var project = projects.FirstOrDefault(p => p.Id == Id);
            projects.Remove(project);
        }
        public IEnumerable<Project> GetAll()
        {
            return projects.AsReadOnly();
        }
        public Task<Project> GetByIdAsync(Guid id)
        {
           var project = projects.FirstOrDefault(p => p.Id == id);
            return Task.FromResult(project);
        }
        public bool ProjectExists(Guid id)
        {
            return projects.Any(p => p.Id == id);
        }
        public Task<Project> UpdateAsync(Project updatedproject)
        {
            var project = projects.FirstOrDefault(p => p.Id == Id);
            if (project != null)
            {
                // project.Update(updatedproject);
                throw new Exception("no projects found");
            }
             project.Title = updatedproject.Title;
             project.Description = updatedproject.Description;
             project.EmployeeId = updatedproject.EmployeeId;
            return Task.FromResult(project);

        }
       
    }
  
}
