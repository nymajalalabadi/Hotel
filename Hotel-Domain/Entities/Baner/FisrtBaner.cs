using Hotel_Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Domain.Entities.Baner
{
    public class FisrtBaner : BaseEntity
    {
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را کامل کنید")]
        public string BanerTitle { get; set; }

        [Display(Name = "متن دکمه")]
        [Required(ErrorMessage = "لطفا {0} را کامل کنید")]
        public string BanerButton { get; set; }

        [Display(Name = "تصویر بنر")]
        [Required(ErrorMessage = "لطفا {0} را کامل کنید")]
        public string ImageName { get; set; }
    }
}
