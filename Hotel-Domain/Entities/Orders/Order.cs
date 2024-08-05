using Hotel_Domain.Entities.Account;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel_Domain.Entities.Common;
using Hotel_Domain.Entities.Hotels;

namespace Hotel_Domain.Entities.Orders
{
    public class Order : BaseEntity
    {
        #region Propertis

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public long UserId { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public long HotelId { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public long OrderSum { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int PassCode { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int Count { get; set; }

        public string? Name { get; set; }

        public string? LastName { get; set; }

        public string? Description { get; set; }

        public bool IsFinilly { get; set; }

        public OrderState OrderState { get; set; }

        #endregion

        #region Relations

        public User User { get; set; }

        public Hotel Hotel { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }

        #endregion

    }

    public enum OrderState
    {
        [Display(Name = "درخواست شده")]
        Requested,
        [Display(Name = "در حال بررسی")]
        Processing,
        [Display(Name = "ثبت شده")]
        Sent,
        [Display(Name = "لغو شده")]
        Cancel
    }
}
