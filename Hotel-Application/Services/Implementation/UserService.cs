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
    }
}
