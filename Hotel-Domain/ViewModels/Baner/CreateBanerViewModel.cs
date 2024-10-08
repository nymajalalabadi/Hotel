﻿using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Hotel_Domain.ViewModels.Baner
{
    public class CreateBanerViewModel
    {
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را کامل کنید")]
        public string BanerTitle { get; set; }

        [Display(Name = "متن دکمه")]
        [Required(ErrorMessage = "لطفا {0} را کامل کنید")]
        public string BanerButton { get; set; }

        [Display(Name = "عکس")]
        [Required(ErrorMessage = "لطفا {0} را کامل کنید")]
        public IFormFile AvatarImage { get; set; }
    }

    public enum CreateBanerResult
    {
        Success,
        Failure
    }
}
