using Hotel_DataLayer.Context;
using Hotel_Domain.Entities.Advantage;
using Hotel_Domain.InterFaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_DataLayer.Repositories
{
    public class AdvantageRepository : IAdvantageRepository
    {
        #region Constructor

        private readonly HotelContext _context;

        public AdvantageRepository(HotelContext context)
        {
            _context = context;
        }

        #endregion

        #region Methods

        #region Advantage

        public async Task<IQueryable<AdvantageRoom>> GetAllAdvantageRooms()
        {
            return _context.AdvantageRooms.Where(a => !a.IsDelete).AsQueryable();
        }

        public async Task<AdvantageRoom?> GetAdvantageRoomById(long id)
        {
            return await _context.AdvantageRooms.FirstOrDefaultAsync(c => c.Id.Equals(id));
        }

        public async Task AddAdvantageRoom(AdvantageRoom advantageRoom)
        {
            await _context.AdvantageRooms.AddAsync(advantageRoom);
        }

        public void UpdateAdvantageRoom(AdvantageRoom advantageRoom)
        {
             _context.AdvantageRooms.Update(advantageRoom);
        }

        #endregion

        #region Selected Room To Advantage

        public async Task<IQueryable<SelectedRoomToAdvantage>> GetAllSelectedRoomToAdvantage()
        {
            return _context.SelectedRoomToAdvantages.Include(a => a.AdvantageRoom).Where(a => !a.IsDelete).AsQueryable();
        }

        public async Task<SelectedRoomToAdvantage?> GetSelectedRoomToAdvantageById(long id)
        {
            return await _context.SelectedRoomToAdvantages.FirstOrDefaultAsync(c => c.Id.Equals(id));
        }

        public async Task AddSelectedRoomToAdvantage(SelectedRoomToAdvantage selectedRoomToAdvantage)
        {
            await _context.SelectedRoomToAdvantages.AddAsync(selectedRoomToAdvantage);
        }

        public void UpdateSelectedRoomToAdvantage(SelectedRoomToAdvantage selectedRoomToAdvantage)
        {
            _context.SelectedRoomToAdvantages.Update(selectedRoomToAdvantage);
        }

        #endregion

        #endregion
    }
}
