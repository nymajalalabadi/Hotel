using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Domain.ViewModels.Reserve
{
    public class CreateReserveDateViewModel
    {
        public long RoomId { get; set; }

        public List<DateTime> reserveDates { get; set; }
    }

    public enum CreateReserveDateResult
    {
        Success,
        Failure,
        IsExit
    }
}
