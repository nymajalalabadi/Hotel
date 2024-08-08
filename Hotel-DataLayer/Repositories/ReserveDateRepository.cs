using Hotel_DataLayer.Context;
using Hotel_Domain.Entities.Reserve;
using Hotel_Domain.InterFaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Hotel_DataLayer.Repositories
{
    public class ReserveDateRepository : IReserveDateRepository
    {
        #region Constructor

        private readonly HotelContext _context;

        public ReserveDateRepository(HotelContext context)
        {
            _context = context;
        }

        #endregion

        #region Methods

        public async Task<IQueryable<ReserveDate>> GetAllReserveDates()
        {
            return _context.ReserveDates.Where(r => !r.IsDelete && r.ReserveTime.Date >= DateTime.Now.Date).AsQueryable();
        }

        public bool IsExistReserveDateById(DateTime date, long id)
        {
            return _context.ReserveDates.Any(x => x.ReserveTime.Date == date.Date && x.Id == id);
        }

        public async Task<ReserveDate?> GetReserveDateById(long reserveId)
        {
            return await _context.ReserveDates.FirstOrDefaultAsync(r => r.Id.Equals(reserveId));
        }

        public async Task<ReserveDate?> GetReserDateByRoomId(long id, long roomId)
        {
           return await  _context.ReserveDates
                .FirstOrDefaultAsync(r => !r.IsReserve && r.RoomId == roomId && r.Id == id && r.Count > 0);
        }

        public async Task<ReserveDate?> GetReserDateById(long id)
        {
            return await _context.ReserveDates.FirstOrDefaultAsync(r => r.Id.Equals(id));
        }

        public async Task CreateReserveDate(ReserveDate reserveDate)
        {
            await _context.ReserveDates.AddAsync(reserveDate);
        }

        public async Task CreateReserveDateRange(List<ReserveDate> reserveDates)
        {
            foreach (var reserveDate in reserveDates)
            {
                await _context.AddRangeAsync(reserveDate);
            }
        }

        public void UpdateReserveDate(ReserveDate reserve)
        {
            _context.ReserveDates.Update(reserve);
        }

        public void RomoveReserveDate(ReserveDate reserve)
        {
            _context.ReserveDates.Remove(reserve);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        #endregion
    }
}
