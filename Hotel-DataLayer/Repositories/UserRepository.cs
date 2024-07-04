using Hotel_DataLayer.Context;
using Hotel_Domain.Entities.Account;
using Hotel_Domain.InterFaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_DataLayer.Repositories
{
    public class UserRepository : IUserRepository
    {
        #region Constructor

        private readonly HotelContext _context;

        public UserRepository(HotelContext context) 
        {
            _context = context;
        }

        #endregion

        #region Methods

        public async Task<bool> IsExistUserByEmail(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email.Equals(email.ToLower().Trim()));
        }

        public async Task<User?> GetUserById(long userId)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id.Equals(userId));
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email.Equals(email.ToLower().Trim()));
        }

        public async Task CreateUser(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public  void UpdateUser(User user)
        {
            _context.Users.Update(user);    
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        #endregion
    }
}
