using Hotel_Domain.Entities.Advantage;
using Hotel_Domain.Entities.Hotels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Domain.InterFaces
{
    public interface IAdvantageRepository
    {
        #region Methods

        #region Advantage

        Task<IQueryable<AdvantageRoom>> GetAllAdvantageRooms();

        Task<AdvantageRoom?> GetAdvantageRoomById(long id);

        Task AddAdvantageRoom(AdvantageRoom advantageRoom);

        void UpdateAdvantageRoom(AdvantageRoom advantageRoom);

        #endregion

        #region Selected Room To Advantage

        Task<IQueryable<SelectedRoomToAdvantage>> GetAllSelectedRoomToAdvantage();

        Task<SelectedRoomToAdvantage?> GetSelectedRoomToAdvantageById(long id);

        Task AddSelectedRoomToAdvantage(SelectedRoomToAdvantage selectedRoomToAdvantage);

        void UpdateSelectedRoomToAdvantage(SelectedRoomToAdvantage selectedRoomToAdvantage);

        #endregion

        #endregion
    }
}
