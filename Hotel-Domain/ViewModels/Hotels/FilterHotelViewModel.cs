using Hotel_Domain.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Domain.ViewModels.Hotels
{
    public class FilterHotelViewModel : Paging<DetailsHotelViewModel>
    {
        [Display(Name = "عنوان")]
        public string? Title { get; set; }
    }
}
