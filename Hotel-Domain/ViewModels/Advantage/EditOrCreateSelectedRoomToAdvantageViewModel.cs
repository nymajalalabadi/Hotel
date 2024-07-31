using Hotel_Domain.Entities.Advantage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Domain.ViewModels.Advantage
{
    public class EditOrCreateSelectedRoomToAdvantageViewModel
    {
        public long RoomId { get; set; }

        public List<long> SelectedAdvantage { get; set; }
    }

    public enum EditOrCreateSelectedRoomToAdvantageResult
    {
        Success,
        NotExistAdvantage,
        HasNotFound
    }
}
