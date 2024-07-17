using Hotel_Application.Services.Interface;
using Hotel_Domain.InterFaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Application.Services.Implementation
{
    public class BanerService : IBanerService
    {
        #region Constructor

        private readonly IBanerRepository _banerRepository;

        public BanerService(IBanerRepository banerRepository)
        {
            _banerRepository = banerRepository;
        }

        #endregion

        #region Methods



        #endregion
    }
}
