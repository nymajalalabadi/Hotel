using Hotel_Application.Generators;
using Hotel_Application.Services.Interface;
using Hotel_Application.Statics;
using Hotel_Domain.Entities.Hotels;
using Hotel_Domain.InterFaces;
using Hotel_Domain.ViewModels.HotelGalleries;
using Hotel_Domain.ViewModels.Hotels;
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

        public async Task<FilterHotelViewModel> FilterHotel(FilterHotelViewModel filterViewModel)
        {
            var query = await _hotelRepository.GetAllHotels();

            #region Filtert

            if (!string.IsNullOrEmpty(filterViewModel.Title))
            {
                query = query.Where(h => h.Title.Contains(filterViewModel.Title));
            }

            #endregion

            query = query.OrderByDescending(h => h.CreateDate);

            var hotels = query.Select(h => new DetailsHotelViewModel()
            {
                Id = h.Id,
                Description = h.Description,
                Title = h.Title,
                EntryTime = h.EntryTime,
                ExitTime = h.ExitTime,
                RoomCount = h.RoomCount!.Value,
                StageCount = h.StageCount!.Value,
                State = h.HotelAddress.State,
                PostalCode = h.HotelAddress.PostalCode,
                Address = h.HotelAddress.Address,
                City = h.HotelAddress.City,
                IsActive = h.IsActive
            });

            #region paging

            await filterViewModel.SetPaging(hotels);

            #endregion

            return filterViewModel;
        }

        public async Task<CreateHotelResult> CreateHotel(CreateHotelViewModel createHotel)
        {
            if (createHotel.Title == null)
            {
                return CreateHotelResult.Failure;
            }

            var hotel = new Hotel()
            {
                Title = createHotel.Title,
                Description = createHotel.Description,
                EntryTime = createHotel.EntryTime,
                ExitTime = createHotel.ExitTime,
                RoomCount = createHotel.RoomCount,
                StageCount = createHotel.StageCount,
                IsActive = createHotel.IsActive,
            };

            await _hotelRepository.AddHotel(hotel);
            await _hotelRepository.SaveChanges();

            var address = new HotelAddress()
            {
                HotelId = hotel.Id,
                Address = createHotel.Address,
                City = createHotel.City,
                State = createHotel.State,
                PostalCode = createHotel.PostalCode
            };

            await _hotelRepository.AddHotelAddress(address);
            await _hotelRepository.SaveChanges();

            return CreateHotelResult.Success;
        }

        public async Task<EditHotelViewModel> GetHotelForEdit(long hotelId)
        {
            var currentHotel = await _hotelRepository.GetHotelById(hotelId);

            if (currentHotel == null)
            {
                return null;
            }

            return new EditHotelViewModel()
            {
                Id = currentHotel.Id,
                Description = currentHotel.Description,
                Title = currentHotel.Title,
                EntryTime = currentHotel.EntryTime,
                ExitTime = currentHotel.ExitTime,
                IsActive = currentHotel.IsActive,
               RoomCount = currentHotel.RoomCount!.Value,
               StageCount = currentHotel.StageCount!.Value,
               Address = currentHotel.HotelAddress.Address,
               City = currentHotel.HotelAddress.City,
               PostalCode = currentHotel.HotelAddress.PostalCode,
               State = currentHotel!.HotelAddress.State,
            };
        }

        public async Task<EditHotelResult> EditHotel(EditHotelViewModel editHotel)
        {
            var currentHotel = await _hotelRepository.GetHotelById(editHotel.Id);

            var currentHotelAdress = await _hotelRepository.GetHotelAddressById(editHotel.Id);

            if (currentHotel == null)
            {
                return EditHotelResult.HasNotFound;
            }

            if (currentHotelAdress == null)
            {
                return EditHotelResult.HasNotFound;
            }

            currentHotel.Title = editHotel.Title;
            currentHotel.Description = editHotel.Description;
            currentHotel.ExitTime = editHotel.ExitTime;
            currentHotel.EntryTime = editHotel.EntryTime;
            currentHotel.IsActive = editHotel.IsActive;
            currentHotel.RoomCount = editHotel.RoomCount;
            currentHotel.StageCount = editHotel.StageCount;

            _hotelRepository.UpdateHotel(currentHotel);

            currentHotelAdress.Address = editHotel.Address;
            currentHotelAdress.PostalCode = editHotel.PostalCode;
            currentHotelAdress.State = editHotel.State;
            currentHotelAdress.City = editHotel.City;

            _hotelRepository.UpdateHotelAddress(currentHotelAdress);

            await _hotelRepository.SaveChanges();

            return EditHotelResult.Success;
        }

        public async Task<bool> DeleteHotel(long hotelId)
        {
            var currentHotel = await _hotelRepository.GetHotelById(hotelId);

            if (currentHotel == null)
            {
                return false;
            }

            currentHotel.IsDelete = true;

            _hotelRepository.UpdateHotel(currentHotel);
            await _hotelRepository.SaveChanges();

            return true;
        }

        public async Task<Hotel?> GetHotelById(long hotelId)
        {
            return await _hotelRepository.GetHotelById(hotelId);
        }

        #endregion

        #region Hotel Gallery

        public async Task<FilterHotelGalleriesViewHtml> FilterHotelGalleries(FilterHotelGalleriesViewHtml filterViewModel)
        {
            var query = await _hotelRepository.GetAllHotelGalleries();

            #region filter

            query = query.Where(c => c.HotelId.Equals(filterViewModel.HotelId)); 

            #endregion

            query = query.OrderByDescending(g => g.CreateDate);

            #region paging

            await filterViewModel.SetPaging(query);

            #endregion

            return filterViewModel;
        }

        public async Task<CreateHoteGallerylResult> CreateHotelGallery(CreateHotelGalleryViewHtml create)
        {
            if (create.AvatarImage != null)
            {
                string imageName = Guid.NewGuid() + Path.GetExtension(create.AvatarImage.FileName);
                create.AvatarImage.AddImageToServer(imageName, SiteTools.HotelImageName);

                var hotelGallery = new HotelGallery()
                {
                    HotelId = create.HotelId,
                    ImageName = imageName,
                };

                await _hotelRepository.AddHotelGallery(hotelGallery);
                await _hotelRepository.SaveChanges();

                return CreateHoteGallerylResult.Success;
            }

            return CreateHoteGallerylResult.Failure;
        }

        public async Task<EditHotelGalleryViewHtml> GetHotelGalleryForEdit(long id)
        {
            var hotelGallery = await _hotelRepository.GetHotelGalleryById(id);

            if (hotelGallery == null)
            {
                return null;
            }

            return new EditHotelGalleryViewHtml()
            {
                ImageName = hotelGallery.ImageName,
                Id = hotelGallery.Id
            };
        }

        public async Task<EditHoteGallerylResult> EditHotelGallery(EditHotelGalleryViewHtml edit)
        {
            var hotelGallery = await _hotelRepository.GetHotelGalleryById(edit.Id);

            if (hotelGallery == null)
            {
                return EditHoteGallerylResult.HasNotFound;
            }

            if (edit.AvatarImage != null)
            {
                string imageName = Guid.NewGuid() + Path.GetExtension(edit.AvatarImage.FileName);
                edit.AvatarImage.AddImageToServer(imageName, SiteTools.HotelImageName, null, null, null, hotelGallery.ImageName);

                hotelGallery.ImageName = imageName;

                _hotelRepository.UpdateHotelGallery(hotelGallery);
                await _hotelRepository.SaveChanges();

                return EditHoteGallerylResult.Success;
            }

            return EditHoteGallerylResult.Failure;
        }

        public async Task<bool> DeleteHotelGallery(long id)
        {
            var hotelGallery = await _hotelRepository.GetHotelGalleryById(id);

            if (hotelGallery == null)
            {
                return false;
            }

            hotelGallery.IsDelete = true;

            _hotelRepository.UpdateHotelGallery(hotelGallery);
            await _hotelRepository.SaveChanges();

            return true;
        }

        #endregion

        #region Hotel Rule

        #endregion

        #region Hotel Room

        #endregion

        #endregion
    }
}
