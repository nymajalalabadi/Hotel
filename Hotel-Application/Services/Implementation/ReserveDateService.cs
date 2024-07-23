using Hotel_Application.Services.Interface;
using Hotel_Domain.InterFaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Application.Services.Implementation
{
    public class ReserveDateService : IReserveDateService
    {
        #region Constructor

        private readonly IReserveDateRepository _reserveDateRepository;

        private readonly IHotelRepository _hotelRepository;

        public ReserveDateService(IReserveDateRepository reserveDateRepository, IHotelRepository hotelRepository)
        {
            _reserveDateRepository = reserveDateRepository;
            _hotelRepository = hotelRepository;
        }

        #endregion

        #region Methods



        #endregion
    }
}
