using Hotel_Domain.ViewModels.Baner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Application.Services.Interface
{
    public interface IBanerService
    {
        #region Methods

        Task<FilterBanerViewModel> FilterBaner(FilterBanerViewModel filter);

        Task<CreateBanerResult> CreateBanerViewModel(CreateBanerViewModel createBaner);

        Task<EditBanerViewModel> GetEditBaner(long id);

        Task<EditBanerResult> EditBaner(EditBanerViewModel editBaner);

        Task<bool> DeleteBaner(long id);

        Task<List<DetailsBanerViewModel>> GetDetailsBaners();

        #endregion
    }
}
