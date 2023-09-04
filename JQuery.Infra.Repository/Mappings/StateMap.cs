using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using JQuery.Domain.Entities;
namespace JQuery.Infra.Repository.Mappings
{
    public class StateMap : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder.ToTable("STATE");

            builder.HasKey(s => s.IdState);

            builder.Property(s => s.IdState)
              .HasColumnName("IDSTATE");

            builder.Property(s => s.StateAcronym)
                .HasColumnName("STATEACRONYM")
                .HasMaxLength(2)
                .IsRequired();


      
        }
    }
}
