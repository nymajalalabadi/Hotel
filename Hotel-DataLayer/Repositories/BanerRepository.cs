using Hotel_DataLayer.Context;
using Hotel_Domain.Entities.Baner;
using Hotel_Domain.InterFaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_DataLayer.Repositories
{
    public class BanerRepository : IBanerRepository
    {
        #region Constructor

        private readonly HotelContext _context;

        public BanerRepository(HotelContext context)
        {
            _context = context;
        }

        #endregion

        #region Methods

        public async Task<IQueryable<FisrtBaner>> GetBaners()
        {
            return _context.FisrtBaners.Where(b => !b.IsDelete).AsQueryable();
        }

        public async Task AddBaner(FisrtBaner baner)
        {
            await _context.FisrtBaners.AddAsync(baner);
        }

        public void UpdateBaner(FisrtBaner baner)
        {
            _context.FisrtBaners.Update(baner);
        }

        public async Task<FisrtBaner?> GetBanerById(long id)
        {
            return await _context.FisrtBaners.FirstOrDefaultAsync(b => b.Id.Equals(id));
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();  
        }

        #endregion
    }
}
