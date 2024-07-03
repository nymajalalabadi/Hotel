using Hotel_Domain.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Application.Services.Interface
{
    public interface IUserService
    {
        #region Methods

        #region register

        Task<RegisterResult> RegisterUser(RegisterViewModel register);

        #endregion

        #endregion
    }
}
