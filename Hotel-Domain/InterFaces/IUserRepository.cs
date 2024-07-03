using Hotel_Domain.Entities.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Domain.InterFaces
{
    public interface IUserRepository
    {
        #region Methods

        Task<bool> IsExistUserByEmail(string email);

        Task<User?> GetUserById(long userId);

        Task CreateUser(User user);

        void UpdateUser(User user);

        Task SaveChanges();

        #endregion
    }
}
