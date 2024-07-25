using Hotel_Domain.Entities.Hotels;
using Hotel_Domain.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Domain.ViewModels.HotelGalleries
{
    public class FilterHotelGalleriesViewHtml : Paging<HotelGallery>
    {
        public long HotelId { get; set; }
    }
}
