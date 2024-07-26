using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Domain.ViewModels.HotelGalleries
{
    public class CreateHotelGalleryViewHtml
    {
        public long HotelId { get; set; }

        [Display(Name = "تصویر")]
        [Required(ErrorMessage = "لطفا {0} را کامل کنید")]
        public IFormFile AvatarImage { get; set; }
    }

    public enum CreateHoteGalleryResult
    {
        Success,
        Failure,
    }
}
