using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Domain.ViewModels.Order
{
    public class BasketViewModel
    {
        public long OrderId { get; set; }

        public long OrderSum { get; set; }

        public List<BasketDetailViewModel> BasketDetailViewModels { get; set; }

    }
}
