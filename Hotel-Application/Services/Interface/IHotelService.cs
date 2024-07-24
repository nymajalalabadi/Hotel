using Hotel_Domain.ViewModels.Hotels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Application.Services.Interface
{
    public interface IHotelService
    {
        #region Methods

        #region Hotel

        Task<FilterHotelViewModel> FilterHotel(FilterHotelViewModel filterViewModel);

        Task<CreateHotelResult> CreateHotel(CreateHotelViewModel createHotel);

        Task<EditHotelViewModel> GetHotelForEdit(long hotelId);

        Task<EditHotelResult> EditHotel(EditHotelViewModel editHotel);

        Task<bool> DeleteHotel(long hotelId);

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
