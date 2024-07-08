using Hotel_Domain.Entities.Account;
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

        #region login

        Task<LoginResult> LoginUser(LoginViewModel login);

        Task<User?> GetUserByEmail(string email);

        #endregion

        #region Methods

        Task<EditUserProfileViewModel> GetUserProfileForEdit(long userId);

        Task<EditUserProfileResult> EditUserProfile(EditUserProfileViewModel editUser);

        #endregion

        #endregion
    }
}
