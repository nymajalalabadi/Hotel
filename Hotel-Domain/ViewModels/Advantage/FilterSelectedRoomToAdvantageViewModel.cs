using Hotel_Domain.Entities.Advantage;
using Hotel_Domain.ViewModels.Common;

namespace Hotel_Domain.ViewModels.Advantage
{
    public class FilterSelectedRoomToAdvantageViewModel : Paging<AdvantageRoom>
    {
        public long RoomId { get; set; }
    }
}
