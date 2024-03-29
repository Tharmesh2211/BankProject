﻿// <auto-generated />
using System;
using BankManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BankManagement.Infrastructure.Migrations
{
    [DbContext(typeof(BankContext))]
    [Migration("20240216071348_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BankManagement.Domain.Model.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AccountNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("CustomerAdhaarNumber")
                        .HasColumnType("bigint");

                    b.Property<string>("CustomerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerPANNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IFSCCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerAdhaarNumber", "CustomerPANNumber");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("BankManagement.Domain.Model.Bank", b =>
                {
                    b.Property<int>("BankID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BankID"));

                    b.Property<string>("BankName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IFSCCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BankID");

                    b.ToTable("Banks");
                });

            modelBuilder.Entity("BankManagement.Domain.Model.Customer", b =>
                {
                    b.Property<long>("AdhaarNumber")
                        .HasColumnType("bigint");

                    b.Property<string>("PANNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("BankId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CustomerDob")
                        .HasColumnType("datetime2");

                    b.Property<string>("CustomerEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("CustomerPhone")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("AdhaarNumber", "PANNumber");

                    b.HasIndex("BankId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("BankManagement.Domain.Model.Account", b =>
                {
                    b.HasOne("BankManagement.Domain.Model.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerAdhaarNumber", "CustomerPANNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("BankManagement.Domain.Model.Customer", b =>
                {
                    b.HasOne("BankManagement.Domain.Model.Bank", "Bank")
                        .WithMany()
                        .HasForeignKey("BankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bank");
                });
#pragma warning restore 612, 618
        }
    }
}
