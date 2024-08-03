using Hotel_Domain.ViewModels.Reserve;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Application.Services.Interface
{
    public interface IReserveDateService
    {
        #region Methods

        Task<FilterReserveDateViewModel> FilterReserveDate(FilterReserveDateViewModel filter);

        Task<CreateReserveDateViewModel> GetReserveDateForCreate(long RoomId);

        Task<CreateReserveDateResult> CreateReserveDate(CreateReserveDateViewModel create);

        Task<EditReserveDateViewModel> GetReserveDateForEdit(long id);

        Task<EditReserveDateResult> EditReserveDate(EditReserveDateViewModel edit);

        Task<bool> DeleteReserveDate(long id);

        #endregion
    }
}
