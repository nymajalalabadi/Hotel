using Hotel_Domain.Entities.Reserve;
using Hotel_Domain.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Domain.ViewModels.Reserve
{
    public class FilterReserveDateViewModel : Paging<ReserveDate>
    {
        public long RoomId { get; set; }
    }
}
