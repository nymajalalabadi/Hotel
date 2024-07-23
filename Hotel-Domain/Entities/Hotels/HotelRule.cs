using Hotel_Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Domain.Entities.Hotels
{
    public class HotelRule : BaseEntity
    {
        #region Propertis

        public long HotelId { get; set; }

        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا {0} را کامل کنید")]
        [MaxLength(500, ErrorMessage = "تعداد کاراکتر ها نمیتواند بیشتر از {1} باشد")]
        [MinLength(2, ErrorMessage = "تعداد کاراکتر ها نمیتواند کمتر از {1} باشد")]
        public string Description { get; set; }

        #endregion

        #region Relations

        public Hotel Hotel { get; set; }

        #endregion
    }
}
