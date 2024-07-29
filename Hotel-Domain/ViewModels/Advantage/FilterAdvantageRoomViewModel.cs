using Hotel_Domain.Entities.Advantage;
using Hotel_Domain.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Domain.ViewModels.Advantage
{
    public class FilterAdvantageRoomViewModel : Paging<AdvantageRoom>
    {
        public string Title { get; set; }
    }
}
