using Hotel_Domain.Entities.Common;
using Hotel_Domain.Entities.Hotels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Domain.Entities.Reserve
{
    public class ReserveDate : BaseEntity
    {
        #region Propertis

        public long RoomId { get; set; }

        [Display(Name = "تاریخ رزرو")]
        [Required(ErrorMessage = "لطفا {0} را کامل کنید")]
        public DateTime ReserveTime { get; set; }

        [Display(Name = "تعداد اتاق")]
        [Required(ErrorMessage = "لطفا {0} را کامل کنید")]
        public int Count { get; set; }

        [Display(Name = "قیمت")]
        [Required(ErrorMessage = "لطفا {0} را کامل کنید")]
        public int Price { get; set; }

        [Display(Name = "وضعیت رزرو")]
        public bool IsReserve { get; set; }

        #endregion

        #region Relations

        public HotelRoom Room { get; set; }

        #endregion
    }
}
