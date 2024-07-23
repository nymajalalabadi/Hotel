using Hotel_Application.Services.Interface;
using Hotel_Domain.InterFaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Application.Services.Implementation
{
    public class AdvantageService : IAdvantageService
    {
        #region Constructor

        private readonly IAdvantageRepository _advantageRepository;

        private readonly IHotelRepository _hotelRepository;

        public AdvantageService(IAdvantageRepository advantageRepository, IHotelRepository hotelRepository)
        {
            _advantageRepository = advantageRepository;
            _hotelRepository = hotelRepository;
        }

        #endregion

        #region Methods

        #region Advantage

        #endregion

        #region Selected Room To Advantage

        #endregion

        #endregion
    }
}
