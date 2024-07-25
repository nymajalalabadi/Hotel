﻿using Hotel_Domain.Entities.Hotels;
using Hotel_Domain.ViewModels.HotelGalleries;
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

        Task<Hotel?> GetHotelById(long hotelId);

        #endregion

        #region Hotel Gallery

        Task<FilterHotelGalleriesViewHtml> FilterHotelGalleries(FilterHotelGalleriesViewHtml filterViewModel);

        Task<CreateHoteGallerylResult> CreateHotelGallery(CreateHotelGalleryViewHtml create);

        Task<EditHotelGalleryViewHtml> GetHotelGalleryForEdit(long id);

        Task<EditHoteGallerylResult> EditHotelGallery(EditHotelGalleryViewHtml edit);

        Task<bool> DeleteHotelGallery(long id);

        #endregion

        #region Hotel Rule

        #endregion

        #region Hotel Room

        #endregion

        #endregion
    }
}
