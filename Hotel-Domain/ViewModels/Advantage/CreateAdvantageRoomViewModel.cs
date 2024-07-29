using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Domain.ViewModels.Advantage
{
    public class CreateAdvantageRoomViewModel
    {
        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا {0} را کامل کنید")]
        [MaxLength(25, ErrorMessage = "تعداد کاراکتر ها نمیتواند بیشتر از {1} باشد")]
        [MinLength(2, ErrorMessage = "تعداد کاراکتر ها نمیتواند کمتر از {1} باشد")]
        public string Name { get; set; }
    }

    public enum CreateAdvantageRoomResult
    {
        Success,
        Failure
    }
}
