using Hotel_Application.Security;
using Hotel_Application.Services.Interface;
using Hotel_Domain.Entities.Account;
using Hotel_Domain.InterFaces;
using Hotel_Domain.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Application.Services.Implementation
{
    public class UserService: IUserService
    {
        #region Constructor

        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        #endregion

        #region Methods

        #region register

        public async Task<RegisterResult> RegisterUser(RegisterViewModel register)
        {
            if (await _userRepository.IsExistUserByEmail(register.Email.ToLower().Trim()))
            {
                return RegisterResult.EmailExists;
            }

            var user = new User()
            {
                Email = register.Email.SanitizeText().ToLower().Trim(),
                Password = PasswordHelper.EncodePasswordMd5(register.Password.SanitizeText()),
            };

            await _userRepository.CreateUser(user);
            await _userRepository.SaveChanges();

            return RegisterResult.Success;
        }

        #endregion

        #region login

        public async Task<LoginResult> LoginUser(LoginViewModel login)
        {
            var user = await _userRepository.GetUserByEmail(login.Email);

            if (user == null)
            {
                return LoginResult.UserNotFound;
            }

            var hashPassword = PasswordHelper.EncodePasswordMd5(login.Password.SanitizeText().ToLower().Trim());

            if (user.Password != hashPassword)
            {
                return LoginResult.UserNotFound;
            }

            if (user.IsDelete)
            {
                return LoginResult.UserIsBan;
            }

            return LoginResult.Success;
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            return await _userRepository.GetUserByEmail(email.ToLower().Trim());    
        }

        #endregion

        #region Methods

        public async Task<EditUserProfileViewModel> GetUserProfileForEdit(long userId)
        {
            var user = await _userRepository.GetUserById(userId);

            if (user == null)
            {
                return null;
            }

            return new EditUserProfileViewModel()
            {
                UserId = user.Id,
                Email = user.Email,
                LastName = user.LastName!,
                Name = user.Name!
            };
        }

        public async Task<EditUserProfileResult> EditUserProfile(EditUserProfileViewModel editUser)
        {
            var user = await _userRepository.GetUserById(editUser.UserId);

            if (user == null)
            {
                return EditUserProfileResult.NotFound;
            }

            user.Name = editUser.Name;
            user.Email = editUser.Email!; 
            user.LastName = editUser.LastName;

            _userRepository.UpdateUser(user);
            await _userRepository.SaveChanges();

            return EditUserProfileResult.Success;
        }

        #endregion

        #endregion
    }
}
