using Hotel_DataLayer.Context;
using Hotel_Domain.InterFaces;
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

        #endregion

        #region Hotel Gallery

        #endregion

        #region Hotel Rule

        #endregion

        #region Hotel Room

        #endregion

        #endregion
    }
}
