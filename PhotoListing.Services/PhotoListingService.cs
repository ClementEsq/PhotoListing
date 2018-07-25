using PhotoListing.Services.Interfaces;
using System;
using PhotoListing.Models.ServiceDTOs.Request;
using PhotoListing.Models.ServiceDTOs.Response;
using System.Collections.Generic;
using System.Threading.Tasks;
using PhotoListing.DataAccess.Interfaces;
using PhotoListing.Services.Extensions;

namespace PhotoListing.Services
{
    public class PhotoListingService : IPhotoListingService
    {
        private IAlbumService _albumService;
        private IPhotoRepository _photoRepository;

        public PhotoListingService(IAlbumService albumService, IPhotoRepository photoRepository)
        {
            _albumService = albumService;
            _photoRepository = photoRepository;
        }

        public async Task<IReadOnlyList<Photo>> GetPagedPhotosAsync(PhotoListingRequest plr)
        {
            IReadOnlyList<Photo> responsePhotos = null;

            try
            {
                var albums = await _albumService.GetAlbumsAsync();
                var constraint = this.CreatePagedPhotoRepositoryConstraint(plr);
                var photos = await _photoRepository.GetPagedPhotosAsync(constraint);
                responsePhotos = this.CreatePagedPhotoResponse(albums, photos);
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return responsePhotos;
        }

        public async Task<IReadOnlyList<Photo>> GetPhotosAsync()
        {
            IReadOnlyList<Photo> responsePhotos = null;

            try
            {
                var albums = await _albumService.GetAlbumsAsync();
                var photos = await _photoRepository.GetPhotosAsync();
                responsePhotos = this.CreatePagedPhotoResponse(albums, photos);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return responsePhotos;        
        }
    }
}
