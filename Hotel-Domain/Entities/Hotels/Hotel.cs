using Hotel_Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Domain.Entities.Hotels
{
    public class Hotel : BaseEntity
    {
        #region Propertis

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را کامل کنید")]
        [MaxLength(50, ErrorMessage = "تعداد کاراکتر ها نمیتواند بیشتر از {1} باشد")]
        [MinLength(2, ErrorMessage = "تعداد کاراکتر ها نمیتواند کمتر از {1} باشد")]
        public string Title { get; set; }

        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا {0} را کامل کنید")]
        [MaxLength(500, ErrorMessage = "تعداد کاراکتر ها نمیتواند بیشتر از {1} باشد")]
        [MinLength(20, ErrorMessage = "تعداد کاراکتر ها نمیتواند کمتر از {1} باشد")]
        public string Description { get; set; }

        [Display(Name = "تعداد اتاق")]
        public int? RoomCount { get; set; }

        [Display(Name = "تعداد طبقه")]
        public int? StageCount { get; set; }

        [Display(Name = "زمان ورود")]
        [Required(ErrorMessage = "لطفا {0} را کامل کنید")]
        public string EntryTime { get; set; }

        [Display(Name = "زمان خروج")]
        [Required(ErrorMessage = "لطفا {0} را کامل کنید")]
        public string ExitTime { get; set; }

        [Display(Name = "تاریخ ثبت")]
        public DateTime? dateTime { get; set; }

        [Display(Name = "وضعیت")]
        public bool IsActive { get; set; }

        #endregion

        #region Relations

        public HotelAddress HotelAddress { get; set; }

        public ICollection<HotelGallery> HotelGalleries { get; set; }

        public ICollection<HotelRoom> HotelRooms { get; set; }

        public ICollection<HotelRule> HotelRules { get; set; }

        #endregion
    }
}
