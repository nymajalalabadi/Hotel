using Hotel_Domain.Entities.Account;
using Hotel_Domain.Entities.Advantage;
using Hotel_Domain.Entities.Baner;
using Hotel_Domain.Entities.Hotels;
using Hotel_Domain.Entities.Orders;
using Hotel_Domain.Entities.Reserve;
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

        public DbSet<HotelRule> HotelRules { get; set; }

        public DbSet<ReserveDate> ReserveDates { get; set; }

        public DbSet<AdvantageRoom> AdvantageRooms { get; set; }

        public DbSet<SelectedRoomToAdvantage> SelectedRoomToAdvantages { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<OrderReserveDate> OrderReserveDates { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Hotel Address

            modelBuilder.Entity<HotelAddress>()
                .HasOne(a => a.Hotel)
                .WithOne(a => a.HotelAddress)
                .HasForeignKey<HotelAddress>(a => a.HotelId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Order>()
                .HasOne(a => a.User)
                .WithMany(a => a.Orders)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Order>()
                .HasOne(a => a.Hotel)
                .WithMany(a => a.Orders)
                .HasForeignKey(a => a.HotelId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrderDetail>()
                .HasOne(a => a.Order)
                .WithMany(a => a.OrderDetails)
                .HasForeignKey(a => a.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrderDetail>()
                .HasOne(a => a.HotelRoom)
                .WithMany(a => a.OrderDetails)
                .HasForeignKey(a => a.HotelRoomId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrderReserveDate>()
                .HasOne(a => a.OrderDetail)
                .WithMany(a => a.OrderReserveDates)
                .HasForeignKey(a => a.OrderDetailId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrderReserveDate>()
                .HasOne(a => a.ReserveDate)
                .WithMany(a => a.OrderReserveDates)
                .HasForeignKey(a => a.ReserveDateId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion
        }
    }
}
