using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel_Domain.Entities.Common;
using Hotel_Domain.Entities.Reserve;

namespace Hotel_Domain.Entities.Orders
{
    public class OrderReserveDate : BaseEntity
    {
        #region Propertis

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public long ReserveDateId { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public long OrderDetailId { get; set; }

        public int Count { get; set; }

        public int Price { get; set; }

        #endregion

        #region Relations

        public ReserveDate ReserveDate { get; set; }

        public OrderDetail OrderDetail { get; set; }

        #endregion
    }
}
