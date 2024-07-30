using Hotel_Domain.Entities.Advantage;
using Hotel_Domain.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Domain.ViewModels.Advantage
{
    public class FilterAdvantageRoomViewModel : Paging<AdvantageRoom>
    {
        [Display(Name = "نام")]
        public string? Name { get; set; }
    }
}
