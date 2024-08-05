using Hotel_Domain.Entities.Common;
using Hotel_Domain.Entities.Hotels;
using Hotel_Domain.Entities.Orders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Domain.Entities.Account
{
    public class User : BaseEntity
    {
        #region Propertis

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را کامل کنید")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نمی باشد .")]
        public string Email { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0} را کامل کنید")]
        public string Password { get; set; }

        [Display(Name = "نام")]
        public string? Name { get; set; }

        [Display(Name = "نام خانوادگی")]
        public string? LastName { get; set; }

        #endregion


        #region Relations

        public ICollection<Order> Orders { get; set; }

        #endregion
    }
}
