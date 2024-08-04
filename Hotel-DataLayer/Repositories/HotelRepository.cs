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

        public async Task<IQueryable<Hotel>> GetAllHotelsForShow()
        {
            return _context.Hotels
               .Include(h => h.HotelAddress)
               .Include(h => h.HotelGalleries)
               .Include(h => h.HotelRooms)
               .Include(h => h.HotelRules)
               .Where(h => !h.IsDelete && h.IsActive)
               .AsQueryable();
        }

        public async Task<Hotel?> GetHotelById(long id)
        {
            return await _context.Hotels.Where(h => !h.IsDelete)
                .Include(h => h.HotelAddress)
                .FirstOrDefaultAsync(h => h.Id.Equals(id));
        }

        public async Task<Hotel?> GetDetailsHotelById(long id)
        {
            return await _context.Hotels.Where(h => !h.IsDelete)
                .Include(h => h.HotelAddress)
                .Include(h => h.HotelGalleries)
                .Include(h => h.HotelRules)
                .FirstOrDefaultAsync(h => h.Id.Equals(id));
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

        public async Task<IQueryable<HotelGallery>> GetAllHotelGalleries()
        {
            return _context.HotelGalleries.Include(g => g.Hotel)
                .Where(g => !g.IsDelete)
                .AsQueryable();
        }

        public async Task<HotelGallery?> GetHotelGalleryById(long id)
        {
            return await _context.HotelGalleries.Include(g => g.Hotel)
                .Where(g => !g.IsDelete)
                .FirstOrDefaultAsync(c => c.Id.Equals(id));
        }

        public async Task AddHotelGallery(HotelGallery hotelGallery)
        {
            await _context.HotelGalleries.AddAsync(hotelGallery);
        }

        public void UpdateHotelGallery(HotelGallery hotelGallery)
        {
            _context.HotelGalleries.Update(hotelGallery);
        }

        #endregion

        #region Hotel Rule

        public async Task<IQueryable<HotelRule>> GetAllHotelRules()
        {
            return _context.HotelRules.Include(g => g.Hotel).Where(g => !g.IsDelete).AsQueryable();
        }

        public async Task<HotelRule?> GetHotelRuleById(long id)
        {
            return await _context.HotelRules.Include(g => g.Hotel)
                .Where(g => !g.IsDelete)
                .FirstOrDefaultAsync(c => c.Id.Equals(id));
        }

        public async Task AddHotelRule(HotelRule hotelRule)
        {
            await _context.HotelRules.AddAsync(hotelRule);
        }

        public void UpdateHotelRule(HotelRule hotelRule)
        {
            _context.HotelRules.Update(hotelRule);
        }

        #endregion

        #region Hotel Room

        public async Task<IQueryable<HotelRoom>> GetAllHotelRooms()
        {
            return _context.HotelRooms
                .Include(g => g.SelectedRoomToAdvantages)
                .ThenInclude(r => r.AdvantageRoom)
                .Include(r => r.ReserveDates)
                .Where(g => !g.IsDelete).AsQueryable();
        }

        public async Task<HotelRoom?> GetHotelRoomById(long id)
        {
            return await _context.HotelRooms.Include(g => g.Hotel)
                .Where(g => !g.IsDelete)
                .FirstOrDefaultAsync(c => c.Id.Equals(id));
        }

        public async Task AddHotelRoom(HotelRoom hotelRoom)
        {
            await _context.HotelRooms.AddAsync(hotelRoom);
        }

        public void UpdateHotelRoom(HotelRoom hotelRoom)
        {
            _context.HotelRooms.Update(hotelRoom);
        }

        public async Task<List<HotelRoom>> GetHotelRoomsByHotelId(long hotelId)
        {
            return await _context.HotelRooms
                .Include(g => g.Hotel)
                .Include(g => g.ReserveDates)
                .Include(g => g.SelectedRoomToAdvantages).ThenInclude(s => s.AdvantageRoom)
                .Where(r => r.HotelId == hotelId & !r.IsDelete)
                .ToListAsync();
        }

        #endregion

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        #endregion
    }
}
