﻿// <auto-generated />
using MVCNEW.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MVCNEW.Migrations
{
    [DbContext(typeof(MVCDbContext))]
    [Migration("20230620084553_Initial Migration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.5.23280.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MVCNEW.Models.Domain.Bike", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<float>("Bhp")
                        .HasColumnType("real");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("CC")
                        .HasColumnType("real");

                    b.Property<string>("ModelNum")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Torque")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Bikes");
                });
#pragma warning restore 612, 618
        }
    }
}
