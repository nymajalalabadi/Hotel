using Hotel_Domain.Entities.Advantage;
using Hotel_Domain.Entities.Common;
using Hotel_Domain.Entities.Reserve;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Domain.Entities.Hotels
{
    public class HotelRoom : BaseEntity
    {
        #region Propertis

        public long HotelId { get; set; }

        [Display(Name = "تصویر اتاق")]
        [Required(ErrorMessage = "لطفا {0} را کامل کنید")]
        public string ImageName { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را کامل کنید")]
        [MaxLength(100, ErrorMessage = "تعداد کاراکتر ها نمیتواند بیشتر از {1} باشد")]
        [MinLength(2, ErrorMessage = "تعداد کاراکتر ها نمیتواند کمتر از {1} باشد")]
        public string Title { get; set; }

        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا {0} را کامل کنید")]
        [MaxLength(500, ErrorMessage = "تعداد کاراکتر ها نمیتواند بیشتر از {1} باشد")]
        [MinLength(2, ErrorMessage = "تعداد کاراکتر ها نمیتواند کمتر از {1} باشد")]
        public string Description { get; set; }

        [Display(Name = "قیمت")]
        [Required(ErrorMessage = "لطفا {0} را کامل کنید")]
        public int RoomPrice { get; set; }

        [Display(Name = "تعداد")]
        [Required(ErrorMessage = "لطفا {0} را کامل کنید")]
        public int Count { get; set; }

        [Display(Name = "ظرفیت")]
        [Required(ErrorMessage = "لطفا {0} را کامل کنید")]
        public int Capacity { get; set; }

        [Display(Name = "تعداد تخت")]
        [Required(ErrorMessage = "لطفا {0} را کامل کنید")]
        public int BedCount { get; set; }

        [Display(Name = "وضعیت")]
        [Required(ErrorMessage = "لطفا {0} را کامل کنید")]
        public bool IsActive { get; set; }

        #endregion

        #region Relations

        public Hotel Hotel { get; set; }

        public ICollection<ReserveDate> ReserveDates { get; set; }

        public ICollection<SelectedRoomToAdvantage> SelectedRoomToAdvantages { get; set; }

        #endregion
    }
}
