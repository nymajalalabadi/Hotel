using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Domain.ViewModels.Account
{
    public class RegisterViewModel 
    {
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را کامل کنید")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نمی باشد .")]
        public string Email { get; set; }

        [Display(Name = "کلمه عبور")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        [Required(ErrorMessage = "لطفا {0} را کامل کنید")]
        public string Password { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0} را کامل کنید")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        [Compare("Password", ErrorMessage = "کلمه های عبور مغایرت دارند .")]
        public string RePassword { get; set; }
    }

    public enum RegisterResult
    {
        Success,
        EmailExists
    }
}
