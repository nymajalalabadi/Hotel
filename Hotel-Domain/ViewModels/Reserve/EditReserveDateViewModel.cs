using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Domain.ViewModels.Reserve
{
    public class EditReserveDateViewModel
    {
        public long Id { get; set; }

        public long RoomId { get; set; }

        [Display(Name = "تاریخ رزرو")]
        public string? ReserveTime { get; set; }

        [Display(Name = "تعداد اتاق")]
        public int Count { get; set; }

        [Display(Name = "قیمت")]
        public int Price { get; set; }

        [Display(Name = "وضعیت رزرو")]
        public bool IsReserve { get; set; }
    }

    public enum EditReserveDateResult
    {
        Success,
        Failure,
        HasNotFound
    }
}
