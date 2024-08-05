using Hotel_Domain.Entities.Hotels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel_Domain.Entities.Common;

namespace Hotel_Domain.Entities.Orders
{
    public class OrderDetail : BaseEntity
    {
        #region Propertis

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public long OrderId { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public long HotelRoomId { get; set; }

        public int Price { get; set; }

        #endregion

        #region Relations

        public Order Order { get; set; }

        public HotelRoom HotelRoom { get; set; }

        public ICollection<OrderReserveDate> OrderReserveDates { get; set; }

        #endregion

    }
}
