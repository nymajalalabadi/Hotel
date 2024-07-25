using Hotel_Domain.Entities.Hotels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Domain.InterFaces
{
    public interface IHotelRepository
    {
        #region Methods

        #region Hotel

        Task<IQueryable<Hotel>> GetAllHotels();

        Task<Hotel?> GetHotelById(long id);

        Task AddHotel(Hotel hotel);

        void UpdateHotel(Hotel hotel);

        #region Hotel Address

        Task<HotelAddress?> GetHotelAddressById(long id);

        Task AddHotelAddress(HotelAddress hotelAddress);

        void UpdateHotelAddress(HotelAddress hotelAddress);

        #endregion

        #endregion

        #region Hotel Gallery

        Task<IQueryable<HotelGallery>> GetAllHotelGalleries();

        Task<HotelGallery?> GetHotelGalleryById(long id);

        Task AddHotelGallery(HotelGallery hotelGallery);

        void UpdateHotelGallery(HotelGallery hotelGallery);

        #endregion

        #region Hotel Rule

        #endregion

        #region Hotel Room

        #endregion

        Task SaveChanges();

        #endregion
    }
}
