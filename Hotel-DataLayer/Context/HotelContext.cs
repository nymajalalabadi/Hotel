﻿using Hotel_Domain.Entities.Account;
using Hotel_Domain.Entities.Baner;
using Hotel_Domain.Entities.Hotels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_DataLayer.Context
{
    public class HotelContext : DbContext
    {
        #region Constructor

        public HotelContext(DbContextOptions<HotelContext> options) : base(options)
        {

        }

        #endregion

        #region Db Set

        public DbSet<User> Users { get; set; }

        public DbSet<FisrtBaner> FisrtBaners { get; set; }

        public DbSet<Hotel> Hotels { get; set; }

        public DbSet<HotelAddress> HotelAddresses { get; set; }

        public DbSet<HotelGallery> HotelGalleries { get; set; }

        public DbSet<HotelRoom> HotelRooms { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Hotel Address

            modelBuilder.Entity<HotelAddress>()
                .HasOne(a => a.Hotel)
                .WithOne(a => a.hotelAddress)
                .HasForeignKey<HotelAddress>(a => a.HotelId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion
        }
    }
}
