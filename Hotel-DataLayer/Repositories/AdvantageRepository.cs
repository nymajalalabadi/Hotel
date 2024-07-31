using Hotel_DataLayer.Context;
using Hotel_Domain.Entities.Advantage;
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
            return _context.SelectedRoomToAdvantages
                .Include(a => a.AdvantageRoom).Include(a => a.HotelRoom)
                .Where(a => !a.IsDelete).AsQueryable();
        }

        public async Task<List<long>> GetSelectedRoomToAdvantageByRoomId(long roomId)
        {
            return await _context.SelectedRoomToAdvantages
                .Where(c => c.HotelRoomId.Equals(roomId))
                .Select(c => c.AdvantageRoomId)
                .ToListAsync();
        }

        public async Task<SelectedRoomToAdvantage?> GetSelectedRoomToAdvantageById(long id)
        {
            return await _context.SelectedRoomToAdvantages.FirstOrDefaultAsync(c => c.Id.Equals(id));
        }

        public async Task AddSelectedRoomToAdvantage(List<long> selectedRoomToAdvantage, long roomId)
        {
            if (selectedRoomToAdvantage != null && selectedRoomToAdvantage.Any())
            {
                var selectedRoomToAdvantages = new List<SelectedRoomToAdvantage>();

                foreach (var AdvantageId in selectedRoomToAdvantage)
                {
                    selectedRoomToAdvantages.Add(new SelectedRoomToAdvantage()
                    {
                        AdvantageRoomId = AdvantageId,
                        HotelRoomId = roomId
                    });
                }

                await _context.SelectedRoomToAdvantages.AddRangeAsync(selectedRoomToAdvantages);
            }
        }

        public async Task RomveAllSelectedRoomToAdvantage(long roomId)
        {
            var selectedRoomToAdvantage = await _context.SelectedRoomToAdvantages.Where(r => r.HotelRoomId == roomId).ToListAsync();

            if (selectedRoomToAdvantage.Any())
            {
                _context.RemoveRange(selectedRoomToAdvantage);
            }
        }

        #endregion

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        #endregion
    }
}
