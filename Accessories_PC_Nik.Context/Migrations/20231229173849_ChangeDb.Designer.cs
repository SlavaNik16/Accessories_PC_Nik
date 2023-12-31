﻿// <auto-generated />
using System;
using Accessories_PC_Nik.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Accessories_PC_Nik.Context.Migrations
{
    [DbContext(typeof(AccessoriesContext))]
    [Migration("20231229173849_ChangeDb")]
    partial class ChangeDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Accessories_PC_Nik.Context.Contracts.Models.AccessKey", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("Key")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Types")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<Guid>("WorkerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("Types")
                        .HasDatabaseName("IX_AccessKey_Id")
                        .HasFilter("DeletedAt is null");

                    b.HasIndex("WorkerId");

                    b.ToTable("TAccessKey", (string)null);
                });

            modelBuilder.Entity("Accessories_PC_Nik.Context.Contracts.Models.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("Patronymic")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasDatabaseName("IX_Client_Email")
                        .HasFilter("DeletedAt is null");

                    b.HasIndex("Phone")
                        .IsUnique()
                        .HasDatabaseName("IX_Client_Phone")
                        .HasFilter("DeletedAt is null");

                    b.ToTable("TClient", (string)null);
                });

            modelBuilder.Entity("Accessories_PC_Nik.Context.Contracts.Models.Component", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int>("MaterialType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TypeComponents")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("MaterialType")
                        .HasDatabaseName("IX_Component_MaterialType_Id")
                        .HasFilter("DeletedAt is null");

                    b.HasIndex("TypeComponents")
                        .HasDatabaseName("IX_Component_TypeComponents_Id")
                        .HasFilter("DeletedAt is null");

                    b.ToTable("TComponent", (string)null);
                });

            modelBuilder.Entity("Accessories_PC_Nik.Context.Contracts.Models.Delivery", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("From")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("To")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("From")
                        .HasDatabaseName("IX_Delivery_From")
                        .HasFilter("DeletedAt is null");

                    b.ToTable("TDelivery", (string)null);
                });

            modelBuilder.Entity("Accessories_PC_Nik.Context.Contracts.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ComponentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid?>("DeliveryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("OrderTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ServiceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("ComponentId");

                    b.HasIndex("DeliveryId");

                    b.HasIndex("OrderTime")
                        .HasDatabaseName("IX_Order_OrderTime_Id")
                        .HasFilter("DeletedAt is null");

                    b.HasIndex("ServiceId");

                    b.ToTable("TOrder", (string)null);
                });

            modelBuilder.Entity("Accessories_PC_Nik.Context.Contracts.Models.Service", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<float>("Duration")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasDatabaseName("IX_Service_Name")
                        .HasFilter("DeletedAt is null");

                    b.ToTable("TService", (string)null);
                });

            modelBuilder.Entity("Accessories_PC_Nik.Context.Contracts.Models.Worker", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessLevel")
                        .HasColumnType("int");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("DocumentType")
                        .HasColumnType("int");

                    b.Property<DateTime>("IssuedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("IssuedBy")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("Series")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("Number")
                        .IsUnique()
                        .HasDatabaseName("IX_Worker_Number")
                        .HasFilter("DeletedAt is null");

                    b.ToTable("TWorker", (string)null);
                });

            modelBuilder.Entity("Accessories_PC_Nik.Context.Contracts.Models.AccessKey", b =>
                {
                    b.HasOne("Accessories_PC_Nik.Context.Contracts.Models.Worker", "Worker")
                        .WithMany("AccessKeys")
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("Accessories_PC_Nik.Context.Contracts.Models.Order", b =>
                {
                    b.HasOne("Accessories_PC_Nik.Context.Contracts.Models.Client", "Client")
                        .WithMany("Order")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Accessories_PC_Nik.Context.Contracts.Models.Component", "Component")
                        .WithMany("Order")
                        .HasForeignKey("ComponentId");

                    b.HasOne("Accessories_PC_Nik.Context.Contracts.Models.Delivery", "Delivery")
                        .WithMany("Order")
                        .HasForeignKey("DeliveryId");

                    b.HasOne("Accessories_PC_Nik.Context.Contracts.Models.Service", "Service")
                        .WithMany("Order")
                        .HasForeignKey("ServiceId");

                    b.Navigation("Client");

                    b.Navigation("Component");

                    b.Navigation("Delivery");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("Accessories_PC_Nik.Context.Contracts.Models.Worker", b =>
                {
                    b.HasOne("Accessories_PC_Nik.Context.Contracts.Models.Client", "Client")
                        .WithMany("Worker")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Accessories_PC_Nik.Context.Contracts.Models.Client", b =>
                {
                    b.Navigation("Order");

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("Accessories_PC_Nik.Context.Contracts.Models.Component", b =>
                {
                    b.Navigation("Order");
                });

            modelBuilder.Entity("Accessories_PC_Nik.Context.Contracts.Models.Delivery", b =>
                {
                    b.Navigation("Order");
                });

            modelBuilder.Entity("Accessories_PC_Nik.Context.Contracts.Models.Service", b =>
                {
                    b.Navigation("Order");
                });

            modelBuilder.Entity("Accessories_PC_Nik.Context.Contracts.Models.Worker", b =>
                {
                    b.Navigation("AccessKeys");
                });
#pragma warning restore 612, 618
        }
    }
}
