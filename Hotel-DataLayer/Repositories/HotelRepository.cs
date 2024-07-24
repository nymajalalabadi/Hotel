using Hotel_DataLayer.Context;
using Hotel_Domain.Entities.Hotels;
using Hotel_Domain.InterFaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_DataLayer.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        #region Constructor

        private readonly HotelContext _context;

        public HotelRepository(HotelContext context)
        {
            _context = context;
        }

        #endregion

        #region Methods

        #region Hotel

        public async Task<IQueryable<Hotel>> GetAllHotels()
        {
            return _context.Hotels.Include(h => h.HotelAddress)
                .Where(h => !h.IsDelete && h.IsActive)
                .AsQueryable();
        }

        public async Task<Hotel?> GetHotelById(long id)
        {
            return await _context.Hotels.Where(h => !h.IsDelete).FirstOrDefaultAsync(h => h.Id.Equals(id));
        }

        public async Task AddHotel(Hotel hotel)
        {
            await _context.Hotels.AddAsync(hotel);
        }

        public void UpdateHotel(Hotel hotel)
        {
            _context.Hotels.Update(hotel);  
        }

        #region Hotel Address

        public async Task<HotelAddress?> GetHotelAddressById(long id)
        {
            return await _context.HotelAddresses.Include(h => h.Hotel).FirstOrDefaultAsync(h => h.HotelId.Equals(id));
        }

        public async Task AddHotelAddress(HotelAddress hotelAddress)
        {
            await _context.HotelAddresses.AddAsync(hotelAddress);
        }

        public void UpdateHotelAddress(HotelAddress hotelAddress)
        {
             _context.HotelAddresses.Update(hotelAddress);
        }

        #endregion

        #endregion

        #region Hotel Gallery

        #endregion

        #region Hotel Rule

        #endregion

        #region Hotel Room

        #endregion

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        #endregion
    }
}
