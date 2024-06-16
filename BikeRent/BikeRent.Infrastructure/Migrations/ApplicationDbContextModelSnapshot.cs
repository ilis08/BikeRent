﻿// <auto-generated />
using System;
using BikeRent.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BikeRent.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

            modelBuilder.Entity("BikeRent.Domain.Bikes.Bike", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("LastRentedOnUtc")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Bikes", (string)null);
                });

            modelBuilder.Entity("BikeRent.Domain.Rentals.Rental", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("AdditionalServices")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("BikeId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("CancelledOnUtc")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("CompletedOnUtc")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ConfirmedOnUtc")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedOnUtc")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("RejectedOnUtc")
                        .HasColumnType("TEXT");

                    b.Property<int>("RentalStatus")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BikeId");

                    b.HasIndex("UserId");

                    b.ToTable("Rental", (string)null);
                });

            modelBuilder.Entity("BikeRent.Domain.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(320)
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("BikeRent.Domain.Bikes.Bike", b =>
                {
                    b.OwnsOne("BikeRent.Domain.Bikes.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("BikeId")
                                .HasColumnType("TEXT");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("State")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("ZipCode")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("BikeId");

                            b1.ToTable("Bikes");

                            b1.WithOwner()
                                .HasForeignKey("BikeId");
                        });

                    b.OwnsOne("BikeRent.Domain.Shared.Money", "BikeCost", b1 =>
                        {
                            b1.Property<Guid>("BikeId")
                                .HasColumnType("TEXT");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("BikeId");

                            b1.ToTable("Bikes");

                            b1.WithOwner()
                                .HasForeignKey("BikeId");
                        });

                    b.OwnsOne("BikeRent.Domain.Shared.Money", "PricePerSecond", b1 =>
                        {
                            b1.Property<Guid>("BikeId")
                                .HasColumnType("TEXT");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("BikeId");

                            b1.ToTable("Bikes");

                            b1.WithOwner()
                                .HasForeignKey("BikeId");
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("BikeCost")
                        .IsRequired();

                    b.Navigation("PricePerSecond")
                        .IsRequired();
                });

            modelBuilder.Entity("BikeRent.Domain.Rentals.Rental", b =>
                {
                    b.HasOne("BikeRent.Domain.Bikes.Bike", null)
                        .WithMany()
                        .HasForeignKey("BikeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BikeRent.Domain.Users.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("BikeRent.Domain.Rentals.DateRange", "Duration", b1 =>
                        {
                            b1.Property<Guid>("RentalId")
                                .HasColumnType("TEXT");

                            b1.Property<DateTime>("End")
                                .HasColumnType("TEXT");

                            b1.Property<DateTime>("Start")
                                .HasColumnType("TEXT");

                            b1.HasKey("RentalId");

                            b1.ToTable("Rental");

                            b1.WithOwner()
                                .HasForeignKey("RentalId");
                        });

                    b.OwnsOne("BikeRent.Domain.Shared.Money", "AdditionalServicesUpCharge", b1 =>
                        {
                            b1.Property<Guid>("RentalId")
                                .HasColumnType("TEXT");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("RentalId");

                            b1.ToTable("Rental");

                            b1.WithOwner()
                                .HasForeignKey("RentalId");
                        });

                    b.OwnsOne("BikeRent.Domain.Shared.Money", "InsuranceFee", b1 =>
                        {
                            b1.Property<Guid>("RentalId")
                                .HasColumnType("TEXT");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("RentalId");

                            b1.ToTable("Rental");

                            b1.WithOwner()
                                .HasForeignKey("RentalId");
                        });

                    b.OwnsOne("BikeRent.Domain.Shared.Money", "PriceForPeriod", b1 =>
                        {
                            b1.Property<Guid>("RentalId")
                                .HasColumnType("TEXT");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("RentalId");

                            b1.ToTable("Rental");

                            b1.WithOwner()
                                .HasForeignKey("RentalId");
                        });

                    b.OwnsOne("BikeRent.Domain.Shared.Money", "TotalPrice", b1 =>
                        {
                            b1.Property<Guid>("RentalId")
                                .HasColumnType("TEXT");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("RentalId");

                            b1.ToTable("Rental");

                            b1.WithOwner()
                                .HasForeignKey("RentalId");
                        });

                    b.Navigation("AdditionalServicesUpCharge")
                        .IsRequired();

                    b.Navigation("Duration")
                        .IsRequired();

                    b.Navigation("InsuranceFee")
                        .IsRequired();

                    b.Navigation("PriceForPeriod")
                        .IsRequired();

                    b.Navigation("TotalPrice")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
