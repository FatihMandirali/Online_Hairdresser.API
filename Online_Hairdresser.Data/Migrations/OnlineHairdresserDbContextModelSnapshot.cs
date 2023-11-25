﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Online_Hairdresser.Data;

#nullable disable

namespace Online_Hairdresser.Data.Migrations
{
    [DbContext(typeof(OnlineHairdresserDbContext))]
    partial class OnlineHairdresserDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Online_Hairdresser.Data.Entity.CityCounty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CountyName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("PlateNumber")
                        .HasColumnType("integer");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("CityCounties");
                });

            modelBuilder.Entity("Online_Hairdresser.Data.Entity.Onboarding", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Gender")
                        .HasColumnType("integer");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Ordering")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("Onboardings");
                });

            modelBuilder.Entity("Online_Hairdresser.Data.Entity.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("RefreshTokenContent")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("RefreshTokenExpDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("Online_Hairdresser.Data.Entity.Theme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ColorOne")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ColorThree")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ColorTwo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Gender")
                        .HasColumnType("integer");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("Themes");
                });

            modelBuilder.Entity("Online_Hairdresser.Data.Entity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CityCountyId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Gender")
                        .HasColumnType("integer");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Latitude")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Longitude")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NotificationId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Platform")
                        .HasColumnType("integer");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CityCountyId");

                    b.HasIndex("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Online_Hairdresser.Data.Entity.Venue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("CityCountyId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Info")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<double>("Latitude")
                        .HasColumnType("double precision");

                    b.Property<double>("Longitude")
                        .HasColumnType("double precision");

                    b.Property<string>("MainImage")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Motto")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("ProcessInterval")
                        .HasColumnType("double precision");

                    b.Property<double>("Star")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("CityCountyId");

                    b.HasIndex("Id");

                    b.ToTable("Venues");
                });

            modelBuilder.Entity("Online_Hairdresser.Data.Entity.VenueAppointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<TimeSpan>("Hour")
                        .HasColumnType("interval");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ServiceList")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("VenueId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("VenueId");

                    b.ToTable("VenueAppointments");
                });

            modelBuilder.Entity("Online_Hairdresser.Data.Entity.VenueFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("VenueId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.HasIndex("VenueId");

                    b.ToTable("VenueFiles");
                });

            modelBuilder.Entity("Online_Hairdresser.Data.Entity.VenueService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<int>("VenueId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.HasIndex("VenueId");

                    b.ToTable("VenueServices");
                });

            modelBuilder.Entity("Online_Hairdresser.Data.Entity.VenueWorker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ServiceList")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("VenueId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.HasIndex("VenueId");

                    b.ToTable("VenueWorkers");
                });

            modelBuilder.Entity("Online_Hairdresser.Data.Entity.VenueWorkingHour", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Day")
                        .HasColumnType("integer");

                    b.Property<TimeSpan>("EndHour")
                        .HasColumnType("interval");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsOpen")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<TimeSpan>("StartHour")
                        .HasColumnType("interval");

                    b.Property<int>("VenueId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.HasIndex("VenueId");

                    b.ToTable("VenueWorkingHours");
                });

            modelBuilder.Entity("Online_Hairdresser.Data.Entity.User", b =>
                {
                    b.HasOne("Online_Hairdresser.Data.Entity.CityCounty", "CityCounty")
                        .WithMany()
                        .HasForeignKey("CityCountyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CityCounty");
                });

            modelBuilder.Entity("Online_Hairdresser.Data.Entity.Venue", b =>
                {
                    b.HasOne("Online_Hairdresser.Data.Entity.CityCounty", "CityCounty")
                        .WithMany()
                        .HasForeignKey("CityCountyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CityCounty");
                });

            modelBuilder.Entity("Online_Hairdresser.Data.Entity.VenueAppointment", b =>
                {
                    b.HasOne("Online_Hairdresser.Data.Entity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Online_Hairdresser.Data.Entity.Venue", "Venue")
                        .WithMany()
                        .HasForeignKey("VenueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("Venue");
                });

            modelBuilder.Entity("Online_Hairdresser.Data.Entity.VenueFile", b =>
                {
                    b.HasOne("Online_Hairdresser.Data.Entity.Venue", "Venue")
                        .WithMany("VenueFiles")
                        .HasForeignKey("VenueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Venue");
                });

            modelBuilder.Entity("Online_Hairdresser.Data.Entity.VenueService", b =>
                {
                    b.HasOne("Online_Hairdresser.Data.Entity.Venue", "Venue")
                        .WithMany("VenueServices")
                        .HasForeignKey("VenueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Venue");
                });

            modelBuilder.Entity("Online_Hairdresser.Data.Entity.VenueWorker", b =>
                {
                    b.HasOne("Online_Hairdresser.Data.Entity.Venue", "Venue")
                        .WithMany("VenueWorkers")
                        .HasForeignKey("VenueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Venue");
                });

            modelBuilder.Entity("Online_Hairdresser.Data.Entity.VenueWorkingHour", b =>
                {
                    b.HasOne("Online_Hairdresser.Data.Entity.Venue", "Venue")
                        .WithMany()
                        .HasForeignKey("VenueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Venue");
                });

            modelBuilder.Entity("Online_Hairdresser.Data.Entity.Venue", b =>
                {
                    b.Navigation("VenueFiles");

                    b.Navigation("VenueServices");

                    b.Navigation("VenueWorkers");
                });
#pragma warning restore 612, 618
        }
    }
}
