using Hotel_Domain.Entities.Account;
using Hotel_Domain.Entities.Reserve;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Domain.InterFaces
{
    public interface IReserveDateRepository
    {
        #region Methods

        Task<IQueryable<ReserveDate>> GetAllReserveDates();

        bool IsExistReserveDateById(DateTime date, long id);

        Task<ReserveDate?> GetReserveDateById(long reserveId);

        Task<ReserveDate?> GetReserDateByRoomId(long id, long roomId);

        Task<ReserveDate?> GetReserDateById(long id);

        Task CreateReserveDate(ReserveDate reserveDate);

        Task CreateReserveDateRange(List<ReserveDate> reserveDates);

        void UpdateReserveDate(ReserveDate reserve);

        void RomoveReserveDate(ReserveDate reserve);

        Task SaveChanges();

        #endregion
    }
}
