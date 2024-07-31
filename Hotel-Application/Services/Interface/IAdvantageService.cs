using Hotel_Domain.Entities.Advantage;
using Hotel_Domain.ViewModels.Advantage;
using Hotel_Domain.ViewModels.HotelRooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Application.Services.Interface
{
    public interface IAdvantageService
    {
        #region Methods

        #region Advantage

        Task<FilterAdvantageRoomViewModel> FilterAdvantageRooms(FilterAdvantageRoomViewModel filterViewModel);

        Task<List<AdvantageRoom>> GetAllAdvantageRooms();

        Task<CreateAdvantageRoomResult> CreateAdvantageRoom(CreateAdvantageRoomViewModel create);

        Task<EditAdvantageRoomViewModel> GetAdvantageRoomForEdit(long id);

        Task<EditAdvantageRoomResult> EditAdvantageRoom(EditAdvantageRoomViewModel edit);

        Task<bool> DeleteAdvantageRoom(long id);

        #endregion

        #region Selected Room To Advantage

        Task<FilterSelectedRoomToAdvantageViewModel> FilterSelectedRoomToAdvantage(FilterSelectedRoomToAdvantageViewModel filterViewModel);

        Task<EditOrCreateSelectedRoomToAdvantageViewModel> GetSelectedRoomToAdvantage(long id);

        Task<EditOrCreateSelectedRoomToAdvantageResult> CreateOrEditSelectedRoomToAdvantage(EditOrCreateSelectedRoomToAdvantageViewModel createOrEdit);


        #endregion

        #endregion
    }
}
