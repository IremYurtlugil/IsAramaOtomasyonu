﻿// <auto-generated />
using System;
using IsAramaOtomasyonu.FluentAPI.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IsAramaOtomasyonu.FluentAPI.DAL.Migrations
{
    [DbContext(typeof(IsOtomasyonuDbContext))]
    [Migration("20211223182224_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FringeBenefitJob", b =>
                {
                    b.Property<int>("FringeBenefitsFringeBenefitId")
                        .HasColumnType("int");

                    b.Property<int>("JobsJobId")
                        .HasColumnType("int");

                    b.HasKey("FringeBenefitsFringeBenefitId", "JobsJobId");

                    b.HasIndex("JobsJobId");

                    b.ToTable("FringeBenefitJob");
                });

            modelBuilder.Entity("IsAramaOtomasyonu.FluentAPI.Entity.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<byte>("JobRight")
                        .HasColumnType("tinyint");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("char(11)")
                        .HasColumnName("Phone");

                    b.HasKey("CompanyId");

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.ToTable("Company");
                });

            modelBuilder.Entity("IsAramaOtomasyonu.FluentAPI.Entity.FringeBenefit", b =>
                {
                    b.Property<int>("FringeBenefitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("FringeBenefitId");

                    b.ToTable("FringeBenefits");

                    b.HasData(
                        new
                        {
                            FringeBenefitId = 1,
                            Description = "Yol"
                        },
                        new
                        {
                            FringeBenefitId = 2,
                            Description = "Yemek (Sodexe)"
                        },
                        new
                        {
                            FringeBenefitId = 3,
                            Description = "Çay Kahve Parası"
                        },
                        new
                        {
                            FringeBenefitId = 4,
                            Description = "Servis"
                        });
                });

            modelBuilder.Entity("IsAramaOtomasyonu.FluentAPI.Entity.Job", b =>
                {
                    b.Property<int>("JobId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("JobType")
                        .HasColumnType("int");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<byte?>("Quality")
                        .HasColumnType("tinyint");

                    b.Property<decimal?>("Salary")
                        .HasPrecision(8, 2)
                        .HasColumnType("decimal(8,2)");

                    b.HasKey("JobId");

                    b.HasIndex("CompanyId");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("IsAramaOtomasyonu.FluentAPI.Entity.ObjectionableWord", b =>
                {
                    b.Property<int>("ObjectionableWordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Word")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ObjectionableWordId");

                    b.ToTable("ObjectionableWords");

                    b.HasData(
                        new
                        {
                            ObjectionableWordId = 1,
                            Word = "beceriksiz"
                        },
                        new
                        {
                            ObjectionableWordId = 2,
                            Word = "aptal"
                        },
                        new
                        {
                            ObjectionableWordId = 3,
                            Word = "salak"
                        });
                });

            modelBuilder.Entity("IsAramaOtomasyonu.FluentAPI.Entity.QualityScore", b =>
                {
                    b.Property<int>("QualityScoreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte>("Point")
                        .HasColumnType("tinyint");

                    b.HasKey("QualityScoreId");

                    b.HasIndex("Description")
                        .IsUnique();

                    b.ToTable("QualityScores");

                    b.HasData(
                        new
                        {
                            QualityScoreId = 1,
                            Description = "Type Specified",
                            Point = (byte)1
                        },
                        new
                        {
                            QualityScoreId = 2,
                            Description = "Salary Specified",
                            Point = (byte)1
                        },
                        new
                        {
                            QualityScoreId = 3,
                            Description = "Fringe Benefit Specified",
                            Point = (byte)1
                        },
                        new
                        {
                            QualityScoreId = 4,
                            Description = "Not Use Objectionable Words",
                            Point = (byte)2
                        });
                });

            modelBuilder.Entity("FringeBenefitJob", b =>
                {
                    b.HasOne("IsAramaOtomasyonu.FluentAPI.Entity.FringeBenefit", null)
                        .WithMany()
                        .HasForeignKey("FringeBenefitsFringeBenefitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IsAramaOtomasyonu.FluentAPI.Entity.Job", null)
                        .WithMany()
                        .HasForeignKey("JobsJobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IsAramaOtomasyonu.FluentAPI.Entity.Job", b =>
                {
                    b.HasOne("IsAramaOtomasyonu.FluentAPI.Entity.Company", "Company")
                        .WithMany("Jobs")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("IsAramaOtomasyonu.FluentAPI.Entity.Company", b =>
                {
                    b.Navigation("Jobs");
                });
#pragma warning restore 612, 618
        }
    }
}
