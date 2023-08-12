﻿// <auto-generated />
using System;
using Insttantt.DataAccess.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Insttantt.DataAccess.Migrations
{
    [DbContext(typeof(InsttanttDbContext))]
    [Migration("20230812211907_Db Initialize")]
    partial class DbInitialize
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Insttantt.Domain.Entities.Field", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("CreatedOn")
                        .IsRequired()
                        .HasColumnType("datetime");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("ModifiedOn")
                        .IsRequired()
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Field", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Active = true,
                            Code = "F-0001",
                            CreatedBy = "unknow",
                            CreatedOn = new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1167),
                            ModifiedBy = "unknow",
                            ModifiedOn = new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1176),
                            Name = "Primer Nombre"
                        },
                        new
                        {
                            Id = 2,
                            Active = true,
                            Code = "F-0002",
                            CreatedBy = "unknow",
                            CreatedOn = new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1178),
                            ModifiedBy = "unknow",
                            ModifiedOn = new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1179),
                            Name = "Segundo Nombre"
                        },
                        new
                        {
                            Id = 3,
                            Active = true,
                            Code = "F-0003",
                            CreatedBy = "unknow",
                            CreatedOn = new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1181),
                            ModifiedBy = "unknow",
                            ModifiedOn = new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1181),
                            Name = "Primer Apellido"
                        },
                        new
                        {
                            Id = 4,
                            Active = true,
                            Code = "F-0004",
                            CreatedBy = "unknow",
                            CreatedOn = new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1183),
                            ModifiedBy = "unknow",
                            ModifiedOn = new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1184),
                            Name = "Segundo Apellido"
                        },
                        new
                        {
                            Id = 5,
                            Active = true,
                            Code = "F-0005",
                            CreatedBy = "unknow",
                            CreatedOn = new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1185),
                            ModifiedBy = "unknow",
                            ModifiedOn = new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1186),
                            Name = "Tipo de Documento"
                        },
                        new
                        {
                            Id = 6,
                            Active = true,
                            Code = "F-0006",
                            CreatedBy = "unknow",
                            CreatedOn = new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1188),
                            ModifiedBy = "unknow",
                            ModifiedOn = new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1188),
                            Name = "Numero Documento"
                        },
                        new
                        {
                            Id = 7,
                            Active = true,
                            Code = "F-0007",
                            CreatedBy = "unknow",
                            CreatedOn = new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1190),
                            ModifiedBy = "unknow",
                            ModifiedOn = new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1191),
                            Name = "Correo Electronico"
                        },
                        new
                        {
                            Id = 8,
                            Active = true,
                            Code = "F-0008",
                            CreatedBy = "unknow",
                            CreatedOn = new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1192),
                            ModifiedBy = "unknow",
                            ModifiedOn = new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1193),
                            Name = "Url"
                        },
                        new
                        {
                            Id = 9,
                            Active = true,
                            Code = "F-0009",
                            CreatedBy = "unknow",
                            CreatedOn = new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1195),
                            ModifiedBy = "unknow",
                            ModifiedOn = new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1196),
                            Name = "Metodo"
                        },
                        new
                        {
                            Id = 10,
                            Active = true,
                            Code = "F-00010",
                            CreatedBy = "unknow",
                            CreatedOn = new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1197),
                            ModifiedBy = "unknow",
                            ModifiedOn = new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1198),
                            Name = "Body"
                        },
                        new
                        {
                            Id = 11,
                            Active = true,
                            Code = "F-0011",
                            CreatedBy = "unknow",
                            CreatedOn = new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1200),
                            ModifiedBy = "unknow",
                            ModifiedOn = new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1200),
                            Name = "Cliente SMTP"
                        },
                        new
                        {
                            Id = 12,
                            Active = true,
                            Code = "F-0012",
                            CreatedBy = "unknow",
                            CreatedOn = new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1202),
                            ModifiedBy = "unknow",
                            ModifiedOn = new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1203),
                            Name = "Puerto"
                        },
                        new
                        {
                            Id = 13,
                            Active = true,
                            Code = "F-0013",
                            CreatedBy = "unknow",
                            CreatedOn = new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1204),
                            ModifiedBy = "unknow",
                            ModifiedOn = new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1205),
                            Name = "Email From"
                        },
                        new
                        {
                            Id = 14,
                            Active = true,
                            Code = "F-0014",
                            CreatedBy = "unknow",
                            CreatedOn = new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1207),
                            ModifiedBy = "unknow",
                            ModifiedOn = new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1207),
                            Name = "Password"
                        },
                        new
                        {
                            Id = 15,
                            Active = true,
                            Code = "F-0015",
                            CreatedBy = "unknow",
                            CreatedOn = new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1209),
                            ModifiedBy = "unknow",
                            ModifiedOn = new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1210),
                            Name = "Mensaje"
                        },
                        new
                        {
                            Id = 16,
                            Active = true,
                            Code = "F-0016",
                            CreatedBy = "unknow",
                            CreatedOn = new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1211),
                            ModifiedBy = "unknow",
                            ModifiedOn = new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1212),
                            Name = "Asunto"
                        },
                        new
                        {
                            Id = 17,
                            Active = true,
                            Code = "F-0017",
                            CreatedBy = "unknow",
                            CreatedOn = new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1214),
                            ModifiedBy = "unknow",
                            ModifiedOn = new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1214),
                            Name = "Valor X"
                        },
                        new
                        {
                            Id = 18,
                            Active = true,
                            Code = "F-0018",
                            CreatedBy = "unknow",
                            CreatedOn = new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1216),
                            ModifiedBy = "unknow",
                            ModifiedOn = new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1217),
                            Name = "Valor Y"
                        },
                        new
                        {
                            Id = 19,
                            Active = true,
                            Code = "F-0019",
                            CreatedBy = "unknow",
                            CreatedOn = new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1219),
                            ModifiedBy = "unknow",
                            ModifiedOn = new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1219),
                            Name = "Resultado Suma"
                        },
                        new
                        {
                            Id = 20,
                            Active = true,
                            Code = "F-0020",
                            CreatedBy = "unknow",
                            CreatedOn = new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1223),
                            ModifiedBy = "unknow",
                            ModifiedOn = new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1224),
                            Name = "Resultado Resta"
                        },
                        new
                        {
                            Id = 21,
                            Active = true,
                            Code = "F-0021",
                            CreatedBy = "unknow",
                            CreatedOn = new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1225),
                            ModifiedBy = "unknow",
                            ModifiedOn = new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1226),
                            Name = "Resultado Multiplicación"
                        },
                        new
                        {
                            Id = 22,
                            Active = true,
                            Code = "F-0022",
                            CreatedBy = "unknow",
                            CreatedOn = new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1228),
                            ModifiedBy = "unknow",
                            ModifiedOn = new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(1228),
                            Name = "Resultado División"
                        });
                });

            modelBuilder.Entity("Insttantt.Domain.Entities.FieldOptionValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("CreatedOn")
                        .IsRequired()
                        .HasColumnType("datetime");

                    b.Property<int>("IdField")
                        .HasColumnType("int");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("ModifiedOn")
                        .IsRequired()
                        .HasColumnType("datetime");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("IdField");

                    b.ToTable("FieldOptionValue", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Active = true,
                            CreatedBy = "unknow",
                            CreatedOn = new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(4791),
                            IdField = 5,
                            ModifiedBy = "unknow",
                            ModifiedOn = new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(4796),
                            Value = "CC"
                        },
                        new
                        {
                            Id = 2,
                            Active = true,
                            CreatedBy = "unknow",
                            CreatedOn = new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(4798),
                            IdField = 5,
                            ModifiedBy = "unknow",
                            ModifiedOn = new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(4798),
                            Value = "NIT"
                        },
                        new
                        {
                            Id = 3,
                            Active = true,
                            CreatedBy = "unknow",
                            CreatedOn = new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(4800),
                            IdField = 5,
                            ModifiedBy = "unknow",
                            ModifiedOn = new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(4800),
                            Value = "TI"
                        },
                        new
                        {
                            Id = 4,
                            Active = true,
                            CreatedBy = "unknow",
                            CreatedOn = new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(4802),
                            IdField = 9,
                            ModifiedBy = "unknow",
                            ModifiedOn = new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(4802),
                            Value = "GET"
                        },
                        new
                        {
                            Id = 5,
                            Active = true,
                            CreatedBy = "unknow",
                            CreatedOn = new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(4804),
                            IdField = 9,
                            ModifiedBy = "unknow",
                            ModifiedOn = new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(4804),
                            Value = "POST"
                        },
                        new
                        {
                            Id = 6,
                            Active = true,
                            CreatedBy = "unknow",
                            CreatedOn = new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(4806),
                            IdField = 9,
                            ModifiedBy = "unknow",
                            ModifiedOn = new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(4806),
                            Value = "PUT"
                        },
                        new
                        {
                            Id = 7,
                            Active = true,
                            CreatedBy = "unknow",
                            CreatedOn = new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(4808),
                            IdField = 9,
                            ModifiedBy = "unknow",
                            ModifiedOn = new DateTime(2023, 8, 12, 16, 19, 7, 735, DateTimeKind.Local).AddTicks(4808),
                            Value = "DELETE"
                        });
                });

            modelBuilder.Entity("Insttantt.Domain.Entities.Flow", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("CreatedOn")
                        .IsRequired()
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("ModifiedOn")
                        .IsRequired()
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Flow", (string)null);
                });

            modelBuilder.Entity("Insttantt.Domain.Entities.FlowExecution", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("CreatedOn")
                        .IsRequired()
                        .HasColumnType("datetime");

                    b.Property<int>("IdFlow")
                        .HasColumnType("int");

                    b.Property<bool>("IsDone")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("ModifiedOn")
                        .IsRequired()
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("IdFlow");

                    b.ToTable("FlowExecution", (string)null);
                });

            modelBuilder.Entity("Insttantt.Domain.Entities.FlowExecutionField", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("CreatedOn")
                        .IsRequired()
                        .HasColumnType("datetime");

                    b.Property<int>("IdFlowExecution")
                        .HasColumnType("int");

                    b.Property<int>("IdFlowStepField")
                        .HasColumnType("int");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("ModifiedOn")
                        .IsRequired()
                        .HasColumnType("datetime");

                    b.Property<string>("value")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.HasIndex("IdFlowExecution");

                    b.HasIndex("IdFlowStepField");

                    b.ToTable("FlowExecutionField", (string)null);
                });

            modelBuilder.Entity("Insttantt.Domain.Entities.FlowStep", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("CreatedOn")
                        .IsRequired()
                        .HasColumnType("datetime");

                    b.Property<int>("IdFlow")
                        .HasColumnType("int");

                    b.Property<int>("IdStep")
                        .HasColumnType("int");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("ModifiedOn")
                        .IsRequired()
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("IdFlow");

                    b.HasIndex("IdStep");

                    b.ToTable("FlowStep", (string)null);
                });

            modelBuilder.Entity("Insttantt.Domain.Entities.FlowStepField", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("CreatedOn")
                        .IsRequired()
                        .HasColumnType("datetime");

                    b.Property<string>("DefaultValue")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasDefaultValue("");

                    b.Property<int>("IdField")
                        .HasColumnType("int");

                    b.Property<int>("IdFlowStep")
                        .HasColumnType("int");

                    b.Property<bool>("IsOutput")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("ModifiedOn")
                        .IsRequired()
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("IdField");

                    b.HasIndex("IdFlowStep");

                    b.ToTable("FlowStepField", (string)null);
                });

            modelBuilder.Entity("Insttantt.Domain.Entities.Step", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("CreatedOn")
                        .IsRequired()
                        .HasColumnType("datetime");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("ModifiedOn")
                        .IsRequired()
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Step", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Active = true,
                            Code = "STP-0001",
                            CreatedBy = "unknow",
                            CreatedOn = new DateTime(2023, 8, 12, 16, 19, 7, 737, DateTimeKind.Local).AddTicks(6132),
                            ModifiedBy = "unknow",
                            ModifiedOn = new DateTime(2023, 8, 12, 16, 19, 7, 737, DateTimeKind.Local).AddTicks(6146),
                            Name = "Formulario Usuario"
                        },
                        new
                        {
                            Id = 2,
                            Active = true,
                            Code = "STP-0002",
                            CreatedBy = "unknow",
                            CreatedOn = new DateTime(2023, 8, 12, 16, 19, 7, 737, DateTimeKind.Local).AddTicks(6148),
                            ModifiedBy = "unknow",
                            ModifiedOn = new DateTime(2023, 8, 12, 16, 19, 7, 737, DateTimeKind.Local).AddTicks(6149),
                            Name = "Consumir Servicio Externo"
                        },
                        new
                        {
                            Id = 3,
                            Active = true,
                            Code = "STP-0003",
                            CreatedBy = "unknow",
                            CreatedOn = new DateTime(2023, 8, 12, 16, 19, 7, 737, DateTimeKind.Local).AddTicks(6150),
                            ModifiedBy = "unknow",
                            ModifiedOn = new DateTime(2023, 8, 12, 16, 19, 7, 737, DateTimeKind.Local).AddTicks(6151),
                            Name = "Enviar Email"
                        },
                        new
                        {
                            Id = 4,
                            Active = true,
                            Code = "STP-0004",
                            CreatedBy = "unknow",
                            CreatedOn = new DateTime(2023, 8, 12, 16, 19, 7, 737, DateTimeKind.Local).AddTicks(6152),
                            ModifiedBy = "unknow",
                            ModifiedOn = new DateTime(2023, 8, 12, 16, 19, 7, 737, DateTimeKind.Local).AddTicks(6153),
                            Name = "Enviar Valores"
                        },
                        new
                        {
                            Id = 5,
                            Active = true,
                            Code = "STP-0005",
                            CreatedBy = "unknow",
                            CreatedOn = new DateTime(2023, 8, 12, 16, 19, 7, 737, DateTimeKind.Local).AddTicks(6154),
                            ModifiedBy = "unknow",
                            ModifiedOn = new DateTime(2023, 8, 12, 16, 19, 7, 737, DateTimeKind.Local).AddTicks(6155),
                            Name = "Ejecutar Ecuación"
                        });
                });

            modelBuilder.Entity("Insttantt.Domain.Entities.FieldOptionValue", b =>
                {
                    b.HasOne("Insttantt.Domain.Entities.Field", "Field")
                        .WithMany("fieldOptionValues")
                        .HasForeignKey("IdField")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_FieldOptionValue_Field");

                    b.Navigation("Field");
                });

            modelBuilder.Entity("Insttantt.Domain.Entities.FlowExecution", b =>
                {
                    b.HasOne("Insttantt.Domain.Entities.Flow", "Flow")
                        .WithMany("Executions")
                        .HasForeignKey("IdFlow")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_FlowExecution_Flow");

                    b.Navigation("Flow");
                });

            modelBuilder.Entity("Insttantt.Domain.Entities.FlowExecutionField", b =>
                {
                    b.HasOne("Insttantt.Domain.Entities.FlowExecution", "FlowExecution")
                        .WithMany("Fields")
                        .HasForeignKey("IdFlowExecution")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_FlowExecutionField_FlowExecution");

                    b.HasOne("Insttantt.Domain.Entities.FlowStepField", "FlowStepField")
                        .WithMany("FlowExecutionFields")
                        .HasForeignKey("IdFlowStepField")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_FlowExecutionField_FlowStepField");

                    b.Navigation("FlowExecution");

                    b.Navigation("FlowStepField");
                });

            modelBuilder.Entity("Insttantt.Domain.Entities.FlowStep", b =>
                {
                    b.HasOne("Insttantt.Domain.Entities.Flow", "Flow")
                        .WithMany("Steps")
                        .HasForeignKey("IdFlow")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_FlowStep_Flow");

                    b.HasOne("Insttantt.Domain.Entities.Step", "Step")
                        .WithMany("FlowSteps")
                        .HasForeignKey("IdStep")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_FlowStep_Step");

                    b.Navigation("Flow");

                    b.Navigation("Step");
                });

            modelBuilder.Entity("Insttantt.Domain.Entities.FlowStepField", b =>
                {
                    b.HasOne("Insttantt.Domain.Entities.Field", "Field")
                        .WithMany("FlowStepFields")
                        .HasForeignKey("IdField")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_FlowStepField_Field");

                    b.HasOne("Insttantt.Domain.Entities.FlowStep", "FlowStep")
                        .WithMany("Fields")
                        .HasForeignKey("IdFlowStep")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_FlowStepField_FlowStep");

                    b.Navigation("Field");

                    b.Navigation("FlowStep");
                });

            modelBuilder.Entity("Insttantt.Domain.Entities.Field", b =>
                {
                    b.Navigation("FlowStepFields");

                    b.Navigation("fieldOptionValues");
                });

            modelBuilder.Entity("Insttantt.Domain.Entities.Flow", b =>
                {
                    b.Navigation("Executions");

                    b.Navigation("Steps");
                });

            modelBuilder.Entity("Insttantt.Domain.Entities.FlowExecution", b =>
                {
                    b.Navigation("Fields");
                });

            modelBuilder.Entity("Insttantt.Domain.Entities.FlowStep", b =>
                {
                    b.Navigation("Fields");
                });

            modelBuilder.Entity("Insttantt.Domain.Entities.FlowStepField", b =>
                {
                    b.Navigation("FlowExecutionFields");
                });

            modelBuilder.Entity("Insttantt.Domain.Entities.Step", b =>
                {
                    b.Navigation("FlowSteps");
                });
#pragma warning restore 612, 618
        }
    }
}
