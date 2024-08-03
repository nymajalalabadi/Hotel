using Hotel_Application.Convertor;
using Hotel_Application.Services.Interface;
using Hotel_Domain.Entities.Reserve;
using Hotel_Domain.InterFaces;
using Hotel_Domain.ViewModels.Reserve;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Application.Services.Implementation
{
    public class ReserveDateService : IReserveDateService
    {
        #region Constructor

        private readonly IReserveDateRepository _reserveDateRepository;

        private readonly IHotelRepository _hotelRepository;

        public ReserveDateService(IReserveDateRepository reserveDateRepository, IHotelRepository hotelRepository)
        {
            _reserveDateRepository = reserveDateRepository;
            _hotelRepository = hotelRepository;
        }

        #endregion

        #region Methods

        public async Task<FilterReserveDateViewModel> FilterReserveDate(FilterReserveDateViewModel filter)
        {
            var query = await _reserveDateRepository.GetAllReserveDates();

            #region filter

            query = query.Where(r => r.RoomId == filter.RoomId);

            #endregion

            query = query.OrderByDescending(r => r.CreateDate);

            #region paging

            await filter.SetPaging(query);

            #endregion

            return filter;
        }

        public async Task<CreateReserveDateViewModel> GetReserveDateForCreat(long RoomId)
        {
            var room = await _hotelRepository.GetHotelRoomById(RoomId);

            if (room == null)
            {
                return null;
            }

            var dateTimes = new List<DateTime>();

            for (int i = 0; i < 30; i++)
            {
                dateTimes.Add(DateTime.Now.AddDays(i));
            }

            return new CreateReserveDateViewModel()
            {
                RoomId = RoomId,
                reserveDates = dateTimes
            };
        }

        public async Task<CreateReserveDateResult> CreateReserveDate(CreateReserveDateViewModel create)
        {
            var room = await _hotelRepository.GetHotelRoomById(create.RoomId);

            if (room == null)
            {
                return CreateReserveDateResult.Failure;
            }

            var dates = new List<ReserveDate>();

            foreach (var date in create.reserveDates)
            {
                if (_reserveDateRepository.IsExistReserveDateById(date, room.Id))
                {
                    return CreateReserveDateResult.IsExit;
                }

                dates.Add(new ReserveDate()
                {
                    RoomId = room.Id,
                    Count = room.Count,
                    ReserveTime = date,
                    Price = room.RoomPrice
                });
            }

            await _reserveDateRepository.CreateReserveDateRange(dates);
            await _reserveDateRepository.SaveChanges();

            return CreateReserveDateResult.Success;
        }

        public async Task<EditReserveDateViewModel> GetReserveDateForEdit(long id)
        {
            var date = await _reserveDateRepository.GetReserveDateById(id);

            if (date == null)
            {
                return null;
            }

            return new EditReserveDateViewModel()
            {
                Id = date.Id,
                RoomId = date.RoomId,
                Count = date.Count,
                IsReserve = date.IsReserve,
                Price =  date.Price,
                ReserveTime = date.ReserveTime.ToShamsi()
            };
        }

        public async Task<EditReserveDateResult> EditReserveDate(EditReserveDateViewModel edit)
        {
            var date = await _reserveDateRepository.GetReserveDateById(edit.Id);

            if (date == null)
            {
                return EditReserveDateResult.HasNotFound;
            }

            date.Price = edit.Price;
            date.ReserveTime = edit.ReserveTime!.ToMiladiDate();
            date.IsReserve = edit.IsReserve;
            date.Count = edit.Count;

            _reserveDateRepository.UpdateReserveDate(date);
            await _reserveDateRepository.SaveChanges();

            return EditReserveDateResult.Success;
        }

        public async Task<bool> DeleteReserveDate(long id)
        {
            var date = await _reserveDateRepository.GetReserveDateById(id);

            if (date == null)
            {
                return false;
            }

            date.IsDelete = true;

            _reserveDateRepository.UpdateReserveDate(date);
            await _reserveDateRepository.SaveChanges();

            return true;
        }

        #endregion
    }
}
