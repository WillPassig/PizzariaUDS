using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzariaUDS.Domain.Models;
using System;

namespace PizzariaUDS.Infra.Data.Mappings
{
    public class PizzaMap : IEntityTypeConfiguration<Pizza>
    {
        public void Configure(EntityTypeBuilder<Pizza> builder)
        {
            builder.Property(p => p.Price)
                .HasColumnName("Price")
                .IsRequired();

            builder.Property(p => p.EstimatedPreparationTime)
                .HasColumnName("EstimatedPreparationTime")
                .IsRequired();

            builder.Property(p => p.Size)
                .HasColumnName("Size")
                .IsRequired();

            builder.Property(p => p.Flavor)
                .HasColumnName("Flavor")
                .IsRequired();
        }
    }
}
