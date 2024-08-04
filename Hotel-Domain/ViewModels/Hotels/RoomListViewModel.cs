using Hotel_Domain.Entities.Advantage;
using Hotel_Domain.Entities.Reserve;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Domain.ViewModels.Hotels
{
    public class RoomListViewModel
    {
        public int Id { get; set; }

        public string ImageName { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int RoomPrice { get; set; }

        public int Count { get; set; }

        public int Capacity { get; set; }

        public int BedCount { get; set; }

        public ICollection<AdvantageRoom> advantagesRoom { get; set; }

        public ICollection<ReserveDate> ReserveDates { get; set; }
    }
}
