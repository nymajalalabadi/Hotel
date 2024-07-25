using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Domain.ViewModels.HotelGalleries
{
    public class EditHotelGalleryViewHtml
    {
        public long Id { get; set; }

        [Display(Name = "اسم تصویر")]
        public string ImageName { get; set; }

        [Display(Name = "تصویر")]
        [Required(ErrorMessage = "لطفا {0} را کامل کنید")]
        public IFormFile AvatarImage { get; set; }
    }

    public enum EditHoteGallerylResult
    {
        Success,
        Failure,
        HasNotFound
    }
}
