using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using JQuery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace JQuery.Infra.Repository.Mappings
{
    public class FriendMap : IEntityTypeConfiguration<Friend>
    {
        public void Configure(EntityTypeBuilder<Friend> builder)
        {
            builder.ToTable("FRIEND");

            builder.HasKey(f => f.IdFriend);

            builder.Property(f => f.IdFriend)
              .HasColumnName("IDFRIEND");

            builder.Property(f => f.FriendName)
                .HasColumnName("FRIENDNAME")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(f => f.Phone)
                .HasColumnName("PHONE")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(f => f.DataCadastro)
              .HasColumnName("DATACADASTRO")
               .IsRequired();

            //Mapeamento dos campos unicos (UNIQUE)
            builder.HasIndex(f => f.FriendName)
                .IsUnique();

            builder.HasIndex(f => f.Phone)
                .IsUnique();

            builder.Property(f => f.IdState)
                .HasColumnName("IDSTATE")
                .IsRequired();

            builder.HasOne(f => f.State) // Configurando relacionamento com State
                .WithMany(s => s.Friends)
                .HasForeignKey(f => f.IdState)
                .OnDelete(DeleteBehavior.Restrict); // Definindo comportamento de exclusão
        }
    }
}
