using Hotel_Application.Services.Interface;
using Hotel_Domain.Entities.Advantage;
using Hotel_Domain.InterFaces;
using Hotel_Domain.ViewModels.Advantage;
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

        public async Task<FilterAdvantageRoomViewModel> FilterAdvantageRooms(FilterAdvantageRoomViewModel filterViewModel)
        {
            var query = await _advantageRepository.GetAllAdvantageRooms();

            #region filter

            if (!string.IsNullOrEmpty(filterViewModel.Name))
            {
                query = query.Where(a => a.Name.Equals(filterViewModel.Name));
            }

            #endregion

            query = query.OrderByDescending(a => a.CreateDate);

            #region paging

            await filterViewModel.SetPaging(query);

            #endregion

            return filterViewModel; 
        }

        public async Task<CreateAdvantageRoomResult> CreateAdvantageRoom(CreateAdvantageRoomViewModel create)
        {
            if (create.Name == null)
            {
                return CreateAdvantageRoomResult.Failure;
            }

            var advantage = new AdvantageRoom()
            {
                Name = create.Name!
            };

            await _advantageRepository.AddAdvantageRoom(advantage);
            await _advantageRepository.SaveChanges();

            return CreateAdvantageRoomResult.Success;
        }

        public async Task<EditAdvantageRoomViewModel> GetAdvantageRoomForEdit(long id)
        {
            var advantage = await _advantageRepository.GetAdvantageRoomById(id);

            if (advantage == null)
            {
                return null;
            }

            return new EditAdvantageRoomViewModel()
            {
                Id = advantage.Id,
                Name = advantage.Name,
            };
        }

        public async Task<EditAdvantageRoomResult> EditAdvantageRoom(EditAdvantageRoomViewModel edit)
        {
            var advantage = await _advantageRepository.GetAdvantageRoomById(edit.Id);

            if (advantage == null)
            {
                return EditAdvantageRoomResult.HasNotFound;
            }

            advantage.Name = edit.Name;

            _advantageRepository.UpdateAdvantageRoom(advantage);
            await _advantageRepository.SaveChanges();

            return EditAdvantageRoomResult.Success;
        }

        public async Task<bool> DeleteAdvantageRoom(long id)
        {
            var advantage = await _advantageRepository.GetAdvantageRoomById(id);

            if (advantage == null)
            {
                return false;
            }

            advantage.IsDelete = true;

            _advantageRepository.UpdateAdvantageRoom(advantage);
            await _advantageRepository.SaveChanges();

            return true;
        }

        #endregion

        #region Selected Room To Advantage

        public Task<FilterSelectedRoomToAdvantageViewModel> FilterSelectedRoomToAdvantage(FilterSelectedRoomToAdvantageViewModel filterViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<EditOrCreateSelectedRoomToAdvantageResult> CreateOrEditSelectedRoomToAdvantage(CreateAdvantageRoomViewModel createOrEdit)
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion
    }
}
