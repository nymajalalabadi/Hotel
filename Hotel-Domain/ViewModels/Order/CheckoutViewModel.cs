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
        public long OrderId { get; set; }

        [Required]
        public long OrderSum { get; set; }

        public string? Name { get; set; }

        public string? LastName { get; set; }

        public long? PassCode { get; set; }

        public int? Count { get; set; }

        public ICollection<BasketDetailViewModel> BasketDetailViewModels { get; set; }
    }

    public enum CheckoutResult
    {
        Success,
        Failure
    }

}
