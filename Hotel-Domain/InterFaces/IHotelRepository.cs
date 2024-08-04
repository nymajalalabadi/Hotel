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

        Task<IQueryable<Hotel>> GetAllHotelsForShow();

        Task<Hotel?> GetHotelById(long id);

        Task<Hotel?> GetDetailsHotelById(long id);

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

        Task<IQueryable<HotelRule>> GetAllHotelRules();

        Task<HotelRule?> GetHotelRuleById(long id);

        Task AddHotelRule(HotelRule hotelRule);

        void UpdateHotelRule(HotelRule hotelRule);

        #endregion

        #region Hotel Room

        Task<IQueryable<HotelRoom>> GetAllHotelRooms();

        Task<HotelRoom?> GetHotelRoomById(long id);

        Task<HotelRoom?> GetHotelRoomForShowById(long id);

        Task AddHotelRoom(HotelRoom hotelRoom);

        void UpdateHotelRoom(HotelRoom hotelRoom);

        Task<List<HotelRoom>> GetHotelRoomsByHotelId(long hotelId);

        #endregion

        Task SaveChanges();

        #endregion
    }
}
