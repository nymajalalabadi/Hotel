using Hotel_Domain.Entities.Advantage;
using Hotel_Domain.ViewModels.Common;

namespace Hotel_Domain.ViewModels.Advantage
{
    public class FilterSelectedRoomToAdvantageViewModel : Paging<SelectedRoomToAdvantage>
    {
        public long RoomId { get; set; }
    }
}
