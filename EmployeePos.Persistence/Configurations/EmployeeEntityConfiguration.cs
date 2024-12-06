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
    public class EmployeeEntityConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("employees", "pos");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.OwnsOne(e => e.FullName, name => 
            {
                name.Property(n => n.FirstName).HasColumnName("first_name").IsRequired(); 
                name.Property(n => n.LastName).HasColumnName("last_name").IsRequired(); 
            });

            builder.Property(e => e.Email)
                .HasColumnName("email")
                .IsRequired(false);

        
        }
    }

}
  