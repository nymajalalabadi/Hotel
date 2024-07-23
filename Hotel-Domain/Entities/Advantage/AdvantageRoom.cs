using Hotel_Domain.Entities.Common;
using Hotel_Domain.Entities.Hotels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Domain.Entities.Advantage
{
    public class AdvantageRoom : BaseEntity
    {
        #region Propertis

        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا {0} را کامل کنید")]
        [MaxLength(25, ErrorMessage = "تعداد کاراکتر ها نمیتواند بیشتر از {1} باشد")]
        [MinLength(2, ErrorMessage = "تعداد کاراکتر ها نمیتواند کمتر از {1} باشد")]
        public string Name { get; set; }

        #endregion

        #region Relations

        public ICollection<SelectedRoomToAdvantage> SelectedRoomToAdvantages { get; set; }

        #endregion
    }
}
