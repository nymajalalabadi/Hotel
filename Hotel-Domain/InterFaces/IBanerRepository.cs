using Hotel_Domain.Entities.Baner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Domain.InterFaces
{
    public interface IBanerRepository
    {
        #region Methods

        Task<IQueryable<FisrtBaner>> GetFisrtBaners();

        Task AddBaner(FisrtBaner baner);

        void UpdateBaner(FisrtBaner baner);

        Task<FisrtBaner?> GetFisrtBanerById(int id);

        Task SaveChanges();

        #endregion
    }
}
