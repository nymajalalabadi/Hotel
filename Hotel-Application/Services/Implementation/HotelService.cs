using Hotel_Application.Services.Interface;
using Hotel_Domain.InterFaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Application.Services.Implementation
{
    public class HotelService : IHotelService
    {
        #region Constructor

        private readonly IHotelRepository _hotelRepository;

        public HotelService(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
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
