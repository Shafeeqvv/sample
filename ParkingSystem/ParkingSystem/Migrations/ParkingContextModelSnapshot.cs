﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ParkingSystem.Model;

#nullable disable

namespace ParkingSystem.Migrations
{
    [DbContext(typeof(ParkingContext))]
    partial class ParkingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ParkingSystem.Model.ParkingLots", b =>
                {
                    b.Property<int>("LotId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LotId"));

                    b.Property<string>("Active")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Latitude")
                        .HasColumnType("real");

                    b.Property<float>("Longitude")
                        .HasColumnType("real");

                    b.Property<string>("Lotname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ManagementContactInformation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OperatingHours")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentMethodsAccepted")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LotId");

                    b.ToTable("ParkingLots");
                });

            modelBuilder.Entity("ParkingSystem.Model.ParkingSpace", b =>
                {
                    b.Property<int>("SpaceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SpaceId"));

                    b.Property<string>("Active")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Coordinates")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EntryTimestamp")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExitTimestamp")
                        .HasColumnType("datetime2");

                    b.Property<int>("LotId")
                        .HasColumnType("int");

                    b.Property<int>("SensorId")
                        .HasColumnType("int");

                    b.Property<string>("SpaceNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SpaceType")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("VehicleDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SpaceId");

                    b.HasIndex("LotId");

                    b.ToTable("ParkingSpaces");
                });

            modelBuilder.Entity("ParkingSystem.Model.ParkingTransactions", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactionId"));

                    b.Property<string>("Active")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("DiscountApplied")
                        .HasColumnType("real");

                    b.Property<float>("Duration")
                        .HasColumnType("real");

                    b.Property<DateTime>("EntryTimestamp")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExitTimestamp")
                        .HasColumnType("datetime2");

                    b.Property<float>("PaymentAmount")
                        .HasColumnType("real");

                    b.Property<int>("PaymentMtd")
                        .HasColumnType("int");

                    b.Property<int>("SpaceId")
                        .HasColumnType("int");

                    b.Property<int>("TransactionStatus")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("VehicleDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TransactionId");

                    b.HasIndex("PaymentMtd");

                    b.HasIndex("SpaceId");

                    b.HasIndex("UserId");

                    b.ToTable("ParkingTransactions");
                });

            modelBuilder.Entity("ParkingSystem.Model.PaymentMethod", b =>
                {
                    b.Property<int>("PaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaId"));

                    b.Property<string>("Active")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PaId");

                    b.ToTable("PaymentMethods");
                });

            modelBuilder.Entity("ParkingSystem.Model.Rates", b =>
                {
                    b.Property<int>("RateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RateId"));

                    b.Property<string>("Active")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ApplicableDays")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EffectiveEndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EffectiveStartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EndTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LotId")
                        .HasColumnType("int");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<int>("RateType")
                        .HasColumnType("int");

                    b.Property<string>("StartTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RateId");

                    b.HasIndex("LotId");

                    b.ToTable("Rates");
                });

            modelBuilder.Entity("ParkingSystem.Model.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<int>("AccountStatus")
                        .HasColumnType("int");

                    b.Property<string>("Active")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phonenumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Usertype")
                        .HasColumnType("int");

                    b.Property<DateTime>("lastLoginDate")
                        .HasColumnType("datetime2");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ParkingSystem.Model.ParkingSpace", b =>
                {
                    b.HasOne("ParkingSystem.Model.ParkingLots", "ParkingLots")
                        .WithMany()
                        .HasForeignKey("LotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ParkingLots");
                });

            modelBuilder.Entity("ParkingSystem.Model.ParkingTransactions", b =>
                {
                    b.HasOne("ParkingSystem.Model.PaymentMethod", "PaymentMethod")
                        .WithMany()
                        .HasForeignKey("PaymentMtd")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ParkingSystem.Model.ParkingSpace", "ParkingSpace")
                        .WithMany()
                        .HasForeignKey("SpaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ParkingSystem.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ParkingSpace");

                    b.Navigation("PaymentMethod");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ParkingSystem.Model.Rates", b =>
                {
                    b.HasOne("ParkingSystem.Model.ParkingLots", "ParkingLots")
                        .WithMany()
                        .HasForeignKey("LotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ParkingLots");
                });
#pragma warning restore 612, 618
        }
    }
}
