using Hotel_Domain.Entities.Hotels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Domain.Entities.Advantage
{
    public class SelectedRoomToAdvantage
    {
        #region Properties

        [Key]
        public long Id { get; set; }

        public long HotelRoomId { get; set; }

        public long AdvantageRoomId { get; set; }

        #endregion

        #region Relations

        public HotelRoom HotelRoom { get; set; }

        public AdvantageRoom AdvantageRoom { get; set; }

        #endregion
    }
}
