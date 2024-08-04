using Hotel_Domain.Entities.Hotels;
using Hotel_Domain.ViewModels.HotelGalleries;
using Hotel_Domain.ViewModels.HotelRooms;
using Hotel_Domain.ViewModels.HotelRules;
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

        Task<FilterHotelViewModel> GetAllHotelForShow(FilterHotelViewModel filterViewModel);

        Task<CreateHotelResult> CreateHotel(CreateHotelViewModel createHotel);

        Task<EditHotelViewModel> GetHotelForEdit(long hotelId);

        Task<EditHotelResult> EditHotel(EditHotelViewModel editHotel);

        Task<bool> DeleteHotel(long hotelId);

        Task<Hotel?> GetHotelById(long hotelId);

        Task<DetailsHotelForShowViewModel?> GetDetailsHotel(long hotelId);

        #endregion

        #region Hotel Gallery

        Task<FilterHotelGalleriesViewHtml> FilterHotelGalleries(FilterHotelGalleriesViewHtml filterViewModel);

        Task<CreateHotelGalleryResult> CreateHotelGallery(CreateHotelGalleryViewHtml create);

        Task<EditHotelGalleryViewHtml> GetHotelGalleryForEdit(long id);

        Task<EditHotelGalleryResult> EditHotelGallery(EditHotelGalleryViewHtml edit);

        Task<bool> DeleteHotelGallery(long id);

        #endregion

        #region Hotel Rule

        Task<FilterHotelRulesViewModel> FilterHotelRules(FilterHotelRulesViewModel filterViewModel);

        Task<CreateHotelRuleResult> CreateHotelRule(CreateHotelRuleViewModel create);

        Task<EditHotelRuleViewModel> GetHotelRuleForEdit(long id);

        Task<EditHotelRuleResult> EditHotelRule(EditHotelRuleViewModel edit);

        Task<bool> DeleteHotelRule(long id);

        #endregion

        #region Hotel Room

        Task<FilterHotelRoomsViewModel> FilterHotelRooms(FilterHotelRoomsViewModel filterViewModel);

        Task<HotelRoom?> GetHotelRoomById(long id);

        Task<CreateHotelRoomResult> CreateHotelRoom(CreateHotelRoomViewModel create);

        Task<EditHotelRoomViewModel> GetHotelRoomForEdit(long id);

        Task<EditHotelRoomResult> EditHotelRoom(EditHotelRoomViewModel edit);

        Task<bool> DeleteHotelRoom(long id);

        Task<List<RoomListViewModel>> GetHotelRoomsByHotelId(long hotelId);

        #endregion

        #endregion
    }
}
