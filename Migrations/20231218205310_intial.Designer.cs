﻿// <auto-generated />
using System;
using DailyEntryArchiving;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DailyEntryArchiving.Migrations
{
    [DbContext(typeof(NitcoContext))]
    [Migration("20231218205310_intial")]
    partial class intial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DailyEntryArchiving.Entities.AccountChart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ArabicName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnglishName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("AccountCharts");
                });

            modelBuilder.Entity("DailyEntryArchiving.Entities.DailyDetailsEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AccountChartId")
                        .HasColumnType("int");

                    b.Property<double>("Credits")
                        .HasColumnType("float");

                    b.Property<int>("DailyEntryId")
                        .HasColumnType("int");

                    b.Property<double>("Debits")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("AccountChartId");

                    b.HasIndex("DailyEntryId");

                    b.ToTable("DailyDetailsEntries");
                });

            modelBuilder.Entity("DailyEntryArchiving.Entities.DailyEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DailyEntries");
                });

            modelBuilder.Entity("DailyEntryArchiving.Entities.DailyDetailsEntry", b =>
                {
                    b.HasOne("DailyEntryArchiving.Entities.AccountChart", "AccountChart")
                        .WithMany("Details")
                        .HasForeignKey("AccountChartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DailyEntryArchiving.Entities.DailyEntry", "DailyEntry")
                        .WithMany("DetailsEntries")
                        .HasForeignKey("DailyEntryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AccountChart");

                    b.Navigation("DailyEntry");
                });

            modelBuilder.Entity("DailyEntryArchiving.Entities.AccountChart", b =>
                {
                    b.Navigation("Details");
                });

            modelBuilder.Entity("DailyEntryArchiving.Entities.DailyEntry", b =>
                {
                    b.Navigation("DetailsEntries");
                });
#pragma warning restore 612, 618
        }
    }
}
