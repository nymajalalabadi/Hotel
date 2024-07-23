using Hotel_Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Domain.Entities.Hotels
{
    public class HotelGallery : BaseEntity
    {
        #region Propertis

        public long HotelId { get; set; }

        [Display(Name = "تصویر")]
        [Required(ErrorMessage = "لطفا {0} را کامل کنید")]
        public string ImageName { get; set; }

        #endregion

        #region Relations

        public Hotel Hotel { get; set; }

        #endregion
    }
}
