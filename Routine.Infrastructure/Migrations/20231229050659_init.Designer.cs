﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Routine.Infrastructure;

#nullable disable

namespace Routine.Infrastructure.Migrations
{
    [DbContext(typeof(RoutineDbContext))]
    [Migration("20231229050659_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Routine.Domain.Entities.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Introduction")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Companies");

                    b.HasData(
                        new
                        {
                            Id = new Guid("bbdee09c-089b-4d30-bece-44df5923716c"),
                            Introduction = "Great Company",
                            Name = "Microsoft"
                        },
                        new
                        {
                            Id = new Guid("6fb600c1-9011-4fd7-9234-881379716440"),
                            Introduction = "Don't be evil",
                            Name = "Google"
                        },
                        new
                        {
                            Id = new Guid("5efc910b-2f45-43df-afae-620d40542853"),
                            Introduction = "Fubao Company",
                            Name = "Alipapa"
                        },
                        new
                        {
                            Id = new Guid("bbdee09c-089b-4d30-bece-44df59237100"),
                            Introduction = "From Shenzhen",
                            Name = "Tencent"
                        },
                        new
                        {
                            Id = new Guid("6fb600c1-9011-4fd7-9234-881379716400"),
                            Introduction = "From Beijing",
                            Name = "Baidu"
                        },
                        new
                        {
                            Id = new Guid("5efc910b-2f45-43df-afae-620d40542800"),
                            Introduction = "Photoshop?",
                            Name = "Adobe"
                        },
                        new
                        {
                            Id = new Guid("bbdee09c-089b-4d30-bece-44df59237111"),
                            Introduction = "Wow",
                            Name = "SpaceX"
                        },
                        new
                        {
                            Id = new Guid("6fb600c1-9011-4fd7-9234-881379716411"),
                            Introduction = "Football Club",
                            Name = "AC Milan"
                        },
                        new
                        {
                            Id = new Guid("5efc910b-2f45-43df-afae-620d40542811"),
                            Introduction = "From Jiangsu",
                            Name = "Suning"
                        },
                        new
                        {
                            Id = new Guid("bbdee09c-089b-4d30-bece-44df59237122"),
                            Introduction = "Blocked",
                            Name = "Twitter"
                        },
                        new
                        {
                            Id = new Guid("6fb600c1-9011-4fd7-9234-881379716422"),
                            Introduction = "Blocked",
                            Name = "Youtube"
                        },
                        new
                        {
                            Id = new Guid("5efc910b-2f45-43df-afae-620d40542822"),
                            Introduction = "- -",
                            Name = "360"
                        },
                        new
                        {
                            Id = new Guid("bbdee09c-089b-4d30-bece-44df59237133"),
                            Introduction = "Brothers",
                            Name = "Jingdong"
                        },
                        new
                        {
                            Id = new Guid("6fb600c1-9011-4fd7-9234-881379716433"),
                            Introduction = "Music?",
                            Name = "NetEase"
                        },
                        new
                        {
                            Id = new Guid("5efc910b-2f45-43df-afae-620d40542833"),
                            Introduction = "Store",
                            Name = "Amazon"
                        },
                        new
                        {
                            Id = new Guid("bbdee09c-089b-4d30-bece-44df59237144"),
                            Introduction = "Not Exists?",
                            Name = "AOL"
                        },
                        new
                        {
                            Id = new Guid("6fb600c1-9011-4fd7-9234-881379716444"),
                            Introduction = "Who?",
                            Name = "Yahoo"
                        },
                        new
                        {
                            Id = new Guid("5efc910b-2f45-43df-afae-620d40542844"),
                            Introduction = "Is it a company?",
                            Name = "Firefox"
                        });
                });

            modelBuilder.Entity("Routine.Domain.Entities.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmployeeNo")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Routine.Domain.Entities.Employee", b =>
                {
                    b.HasOne("Routine.Domain.Entities.Company", "Company")
                        .WithMany("Employees")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Routine.Domain.Entities.Company", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
