﻿// <auto-generated />
using System;
using EFGetStarted.AspNetCore.NewDbPost.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFGetStarted.AspNetCore.NewDbPost.Migrations
{
    [DbContext(typeof(BloggingContext))]
    [Migration("20181025150754_modelNew")]
    partial class modelNew
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFGetStarted.AspNetCore.NewDbPost.Models.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("SSNCompany")
                        .IsRequired();

                    b.Property<string>("Type")
                        .IsRequired();

                    b.HasKey("CompanyId");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("EFGetStarted.AspNetCore.NewDbPost.Models.Local", b =>
                {
                    b.Property<int>("LocalId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("AnnualPayment");

                    b.Property<string>("BussinesName");

                    b.Property<int>("CompanyId");

                    b.Property<DateTime>("ContractEnd");

                    b.Property<DateTime>("ContractStart");

                    b.Property<double>("Deposit");

                    b.Property<string>("Email");

                    b.Property<double>("MonthlyPayment");

                    b.Property<string>("NameOwner");

                    b.Property<double>("PricebySF");

                    b.Property<string>("SpaceID")
                        .IsRequired();

                    b.Property<int>("SquareFoot");

                    b.HasKey("LocalId");

                    b.HasIndex("CompanyId");

                    b.ToTable("Locals");
                });

            modelBuilder.Entity("EFGetStarted.AspNetCore.NewDbPost.Models.Local", b =>
                {
                    b.HasOne("EFGetStarted.AspNetCore.NewDbPost.Models.Company", "Company")
                        .WithMany("Locals")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
