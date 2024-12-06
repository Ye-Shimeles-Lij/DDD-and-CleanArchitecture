using EmployeePos.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePos.Persistence.Configurations
{
    public class PositionEntityConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.ToTable("positions", "pos");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(p => p.Name)
                .HasColumnName("name")
                .IsRequired();

            builder.Property(p => p.Description)
                .HasColumnName("description")
                .IsRequired(false);

            builder.Property(p => p.ParentId)
                .HasColumnName("parent_id")
                .IsRequired(false);
        }
    }
}
