using Hotel_Domain.Entities.Advantage;
using Hotel_Domain.Entities.Reserve;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Domain.ViewModels.HotelRooms
{
    public class SingleRoomViewModel
    {
        public long Id { get; set; }

        public long HotelId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageName { get; set; }

        public int Price { get; set; }

        public int BedCount { get; set; }

        public int Capacity { get; set; }

        public ICollection<AdvantageRoom> advantagesRoom { get; set; }

        public ICollection<ReserveDate> ReserveDates { get; set; }
    }
}
