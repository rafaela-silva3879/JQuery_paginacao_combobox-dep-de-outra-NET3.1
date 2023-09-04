﻿// <auto-generated />
using System;
using JQuery.Infra.Repository.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JQuery.Infra.Repository.Migrations
{
    [DbContext(typeof(SqlServerContext))]
    [Migration("20230819150240_chave")]
    partial class chave
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("JQuery.Domain.Entities.Friend", b =>
                {
                    b.Property<Guid>("IdFriend")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("IDFRIEND");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2")
                        .HasColumnName("DATACADASTRO");

                    b.Property<string>("FriendName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("FRIENDNAME");

                    b.Property<int>("IdState")
                        .HasColumnType("int")
                        .HasColumnName("IDSTATE");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("PHONE");

                    b.HasKey("IdFriend");

                    b.HasIndex("FriendName")
                        .IsUnique();

                    b.HasIndex("IdState");

                    b.HasIndex("Phone")
                        .IsUnique();

                    b.ToTable("FRIEND");
                });

            modelBuilder.Entity("JQuery.Domain.Entities.State", b =>
                {
                    b.Property<int>("IdState")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IDSTATE")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StateAcronym")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)")
                        .HasColumnName("STATEACRONYM");

                    b.HasKey("IdState");

                    b.ToTable("STATE");
                });

            modelBuilder.Entity("JQuery.Domain.Entities.Friend", b =>
                {
                    b.HasOne("JQuery.Domain.Entities.State", "State")
                        .WithMany("Friends")
                        .HasForeignKey("IdState")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("State");
                });

            modelBuilder.Entity("JQuery.Domain.Entities.State", b =>
                {
                    b.Navigation("Friends");
                });
#pragma warning restore 612, 618
        }
    }
}
