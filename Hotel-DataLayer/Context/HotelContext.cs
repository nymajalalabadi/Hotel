using Hotel_Domain.Entities.Account;
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

        #endregion
    }
}
