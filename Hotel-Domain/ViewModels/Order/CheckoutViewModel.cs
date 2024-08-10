using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Domain.ViewModels.Order
{
    public class CheckoutViewModel
    {
        [Required]
        public long OrderSum { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public long PassCode { get; set; }

        [Required]
        public int Count { get; set; }

        public ICollection<BasketDetailViewModel> BasketDetailViewModels { get; set; }
    }
}
