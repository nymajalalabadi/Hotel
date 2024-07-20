using Hotel_Application.Generators;
using Hotel_Application.Services.Interface;
using Hotel_Application.Statics;
using Hotel_Domain.Entities.Baner;
using Hotel_Domain.InterFaces;
using Hotel_Domain.ViewModels.Baner;
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

        public async Task<FilterBanerViewModel> FilterBaner(FilterBanerViewModel filter)
        {
            var query = await _banerRepository.GetFisrtBaners();

            #region filter

            if (!string.IsNullOrEmpty(filter.TitleBanner))
            {
                query = query.Where(b => b.BanerTitle.Contains(filter.TitleBanner));
            }

            #endregion

            query = query.OrderByDescending(b => b.CreateDate);

            #region paging

            await filter.SetPaging(query);

            #endregion

            return filter;
        }

        public async Task<CreateBanerResult> CreateBanerViewModel(CreateBanerViewModel createBaner)
        {
            if (createBaner.BanerTitle == null)
            {
                return CreateBanerResult.Failure;
            }

            if (createBaner.AvatarImage == null)
            {
                return CreateBanerResult.Failure;
            }

            string imageName = Guid.NewGuid() + Path.GetExtension(createBaner.AvatarImage.FileName);
            createBaner.AvatarImage.AddImageToServer(imageName, SiteTools.HotelImageName);

            var baner = new FisrtBaner()
            {
                BanerTitle = createBaner.BanerTitle,
                BanerButton = createBaner.BanerButton,
                ImageName = imageName
            };

            await _banerRepository.AddBaner(baner);
            await _banerRepository.SaveChanges();

            return CreateBanerResult.Success;
        }

        public async Task<EditBanerViewModel> GetEditBaner(long id)
        {
            var currentBaner = await _banerRepository.GetBanerById(id);

            if (currentBaner == null)
            {
                return null;
            }

            return new EditBanerViewModel()
            {
                Id = currentBaner.Id,
                ImageName = currentBaner.ImageName,
                BanerButton = currentBaner.BanerButton,
                BanerTitle = currentBaner.BanerTitle
            };
        }

        public async Task<EditBanerResult> EditBaner(EditBanerViewModel editBaner)
        {
            if (editBaner.AvatarImage != null)
            {
                var currentBanerAvatar = await _banerRepository.GetBanerById(editBaner.Id);

                if (currentBanerAvatar == null)
                {
                    return EditBanerResult.HasNotBaner;
                }

                string newImageName = Guid.NewGuid() + Path.GetExtension(editBaner.AvatarImage.FileName);
                editBaner.AvatarImage.AddImageToServer(newImageName, SiteTools.HotelImageName, null, null, SiteTools.HotelImageName);

                currentBanerAvatar.BanerTitle = editBaner.BanerTitle;
                currentBanerAvatar.BanerButton = editBaner.BanerButton;
                currentBanerAvatar.ImageName = newImageName;

                _banerRepository.UpdateBaner(currentBanerAvatar);
                await _banerRepository.SaveChanges();

                return EditBanerResult.Success;
            }

            var currentBaner = await _banerRepository.GetBanerById(editBaner.Id);

            if (currentBaner == null)
            {
                return EditBanerResult.HasNotBaner;
            }

            currentBaner.BanerTitle = editBaner.BanerTitle;
            currentBaner.BanerButton = editBaner.BanerButton;

            _banerRepository.UpdateBaner(currentBaner);
            await _banerRepository.SaveChanges();

            return EditBanerResult.Success;
        }

        public async Task<bool> DeleteBaner(long id)
        {
            var baner = await _banerRepository.GetBanerById(id);

            if (baner == null)
            {
                return false;
            }

            baner.IsDelete = true;

            _banerRepository.UpdateBaner(baner);
            await _banerRepository.SaveChanges();

            return true;
        }

        #endregion
    }
}
