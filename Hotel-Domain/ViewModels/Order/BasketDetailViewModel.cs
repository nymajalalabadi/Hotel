using Hotel_Domain.Entities.Reserve;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Domain.ViewModels.Order
{
    public class BasketDetailViewModel
    {
        public long DetailId { get; set; }

        public string HotelName { get; set; }

        public string RoomName { get; set; }

        public int BasePrice { get; set; }

        public int TotalPrice { get; set; }

        public ICollection<ReserveDate> ReserveDates { get; set; }
    }
}
