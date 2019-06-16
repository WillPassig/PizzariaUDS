using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzariaUDS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzariaUDS.Infra.Data.Mappings
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(o => o.Id)
                .HasColumnName("Id");

            builder.Property(o => o.Pizza.Price)
                .HasColumnName("Bill")
                .IsRequired();

            builder.Property(o => o.Pizza.EstimatedPreparationTime)
                .HasColumnName("EstimatedPreparationTime")
                .IsRequired();

            builder.Property(o => o.Pizza.Size)
                .HasColumnName("PizzaSize")
                .IsRequired();

            builder.Property(o => o.Pizza.Flavor)
                .HasColumnName("PizzaFlavor")
                .IsRequired();

            builder.Property(o => o.Pizza.Customizations)
                .HasColumnName("PizzaCustomizations");
        }
    }
}
