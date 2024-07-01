using Hotel_DataLayer.Context;
using Hotel_Domain.InterFaces;
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



        #endregion
    }
}
