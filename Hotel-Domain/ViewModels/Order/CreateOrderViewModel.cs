using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Domain.ViewModels.Order
{
    public class CreateOrderViewModel
    {
        public long UserId { get; set; }

        public long RoomId { get; set; }

        public List<long> Dates { get; set; }
    }

}
