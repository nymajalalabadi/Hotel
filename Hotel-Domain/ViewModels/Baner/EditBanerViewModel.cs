using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Domain.ViewModels.Baner
{
    public class EditBanerViewModel
    {
        public long Id { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را کامل کنید")]
        public string? BanerTitle { get; set; }

        [Display(Name = "متن دکمه")]
        [Required(ErrorMessage = "لطفا {0} را کامل کنید")]
        public string? BanerButton { get; set; }

        public string ImageName { get; set; }

        public IFormFile? AvatarImage { get; set; }
    }

    public enum EditBanerResult
    {
        Success,
        Failure,
        HasNotBaner
    }
}
