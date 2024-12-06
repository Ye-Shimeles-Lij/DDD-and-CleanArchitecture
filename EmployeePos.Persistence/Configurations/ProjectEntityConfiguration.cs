using EmployeePos.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePos.Persistence.Configurations
{
    public class ProjectEntityConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {

            builder.ToTable("projects", "pos");
            builder.HasKey(p  => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(p => p.Title)
                .HasColumnName("title")
                .IsRequired();

            builder.Property(p => p.Description)
                .HasColumnName("description")
                .IsRequired(false);

            builder.Property(p => p.EmployeeId)
                .HasColumnName("employee_id")
                .IsRequired();
        }
    }
}
    
