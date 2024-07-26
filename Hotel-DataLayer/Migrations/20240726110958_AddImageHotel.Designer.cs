﻿// <auto-generated />
using System;
using Hotel_DataLayer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Hotel_DataLayer.Migrations
{
    [DbContext(typeof(HotelContext))]
    [Migration("20240726110958_AddImageHotel")]
    partial class AddImageHotel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Hotel_Domain.Entities.Account.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Hotel_Domain.Entities.Advantage.AdvantageRoom", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.ToTable("AdvantageRooms");
                });

            modelBuilder.Entity("Hotel_Domain.Entities.Advantage.SelectedRoomToAdvantage", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("AdvantageRoomId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("HotelRoomId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("AdvantageRoomId");

                    b.HasIndex("HotelRoomId");

                    b.ToTable("SelectedRoomToAdvantages");
                });

            modelBuilder.Entity("Hotel_Domain.Entities.Baner.FisrtBaner", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("BanerButton")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BanerTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("FisrtBaners");
                });

            modelBuilder.Entity("Hotel_Domain.Entities.Hotels.Hotel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("EntryTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExitTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<int?>("RoomCount")
                        .HasColumnType("int");

                    b.Property<int?>("StageCount")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("Hotel_Domain.Entities.Hotels.HotelAddress", b =>
                {
                    b.Property<long>("HotelId")
                        .HasColumnType("bigint");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<string>("PostalCode")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.HasKey("HotelId");

                    b.ToTable("HotelAddresses");
                });

            modelBuilder.Entity("Hotel_Domain.Entities.Hotels.HotelGallery", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("HotelId")
                        .HasColumnType("bigint");

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.ToTable("HotelGalleries");
                });

            modelBuilder.Entity("Hotel_Domain.Entities.Hotels.HotelRoom", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("BedCount")
                        .HasColumnType("int");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<long>("HotelId")
                        .HasColumnType("bigint");

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<int>("RoomPrice")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.ToTable("HotelRooms");
                });

            modelBuilder.Entity("Hotel_Domain.Entities.Hotels.HotelRule", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<long>("HotelId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.ToTable("HotelRules");
                });

            modelBuilder.Entity("Hotel_Domain.Entities.Reserve.ReserveDate", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("HotelRoomId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<bool>("IsReserve")
                        .HasColumnType("bit");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReserveTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HotelRoomId");

                    b.ToTable("ReserveDates");
                });

            modelBuilder.Entity("Hotel_Domain.Entities.Advantage.SelectedRoomToAdvantage", b =>
                {
                    b.HasOne("Hotel_Domain.Entities.Advantage.AdvantageRoom", "AdvantageRoom")
                        .WithMany("SelectedRoomToAdvantages")
                        .HasForeignKey("AdvantageRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hotel_Domain.Entities.Hotels.HotelRoom", "HotelRoom")
                        .WithMany("SelectedRoomToAdvantages")
                        .HasForeignKey("HotelRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AdvantageRoom");

                    b.Navigation("HotelRoom");
                });

            modelBuilder.Entity("Hotel_Domain.Entities.Hotels.HotelAddress", b =>
                {
                    b.HasOne("Hotel_Domain.Entities.Hotels.Hotel", "Hotel")
                        .WithOne("HotelAddress")
                        .HasForeignKey("Hotel_Domain.Entities.Hotels.HotelAddress", "HotelId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("Hotel_Domain.Entities.Hotels.HotelGallery", b =>
                {
                    b.HasOne("Hotel_Domain.Entities.Hotels.Hotel", "Hotel")
                        .WithMany("HotelGalleries")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("Hotel_Domain.Entities.Hotels.HotelRoom", b =>
                {
                    b.HasOne("Hotel_Domain.Entities.Hotels.Hotel", "Hotel")
                        .WithMany("HotelRooms")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("Hotel_Domain.Entities.Hotels.HotelRule", b =>
                {
                    b.HasOne("Hotel_Domain.Entities.Hotels.Hotel", "Hotel")
                        .WithMany("HotelRules")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("Hotel_Domain.Entities.Reserve.ReserveDate", b =>
                {
                    b.HasOne("Hotel_Domain.Entities.Hotels.HotelRoom", "HotelRoom")
                        .WithMany("ReserveDates")
                        .HasForeignKey("HotelRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HotelRoom");
                });

            modelBuilder.Entity("Hotel_Domain.Entities.Advantage.AdvantageRoom", b =>
                {
                    b.Navigation("SelectedRoomToAdvantages");
                });

            modelBuilder.Entity("Hotel_Domain.Entities.Hotels.Hotel", b =>
                {
                    b.Navigation("HotelAddress")
                        .IsRequired();

                    b.Navigation("HotelGalleries");

                    b.Navigation("HotelRooms");

                    b.Navigation("HotelRules");
                });

            modelBuilder.Entity("Hotel_Domain.Entities.Hotels.HotelRoom", b =>
                {
                    b.Navigation("ReserveDates");

                    b.Navigation("SelectedRoomToAdvantages");
                });
#pragma warning restore 612, 618
        }
    }
}
