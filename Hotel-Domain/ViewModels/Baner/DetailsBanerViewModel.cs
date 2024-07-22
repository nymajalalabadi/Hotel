using System.ComponentModel.DataAnnotations;

namespace Hotel_Domain.ViewModels.Baner
{
    public class DetailsBanerViewModel
    {
        public long Id { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را کامل کنید")]
        public string? BanerTitle { get; set; }

        [Display(Name = "متن دکمه")]
        [Required(ErrorMessage = "لطفا {0} را کامل کنید")]
        public string? BanerButton { get; set; }

        public string ImageName { get; set; }
    }
}
