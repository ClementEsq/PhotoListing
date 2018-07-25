using PhotoListing.DataAccess.Interfaces;
using System.Collections.Generic;
using PhotoListing.Models.ClientModels;
using PhotoListing.Models.RepositoryDTOs;
using System.Threading.Tasks;
using System.Linq;
using PhotoListing.DataAccess.Extensions;
using System;

namespace PhotoListing.DataAccess.Repository
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly IClient<Photo> _photoClient;

        public PhotoRepository(IClient<Photo> photoClient)
        {
            _photoClient = photoClient;
        }

        public async Task<Photo> GetAsync(int id)
        {
            var photos = await _photoClient.GetAllAsync();
            var photo = photos.FirstOrDefault(p => p.Id == id);

            return photo;
        }

        public async Task<IReadOnlyList<Photo>> GetPagedPhotosAsync(PagedPhotoConstraint constraint)
        {
            var photos = await _photoClient.GetAllAsync();
            photos = constraint.SortOrder.Equals("desc", StringComparison.CurrentCultureIgnoreCase) ? photos.OrderByDescending(p => p.Title).ToList(): photos.OrderBy(p => p.Title).ToList();
            photos = string.IsNullOrEmpty(constraint.SearchKey) ? photos : this.SearchPhotoList(photos, constraint.SearchKey);
            var pagedPhotos = this.GetPageFromPhotoList(photos, constraint.Page, constraint.PageSize);
            return pagedPhotos;
        }

        public async Task<IReadOnlyList<Photo>> GetPhotosAsync()
        {
            var photos = await _photoClient.GetAllAsync();
            return photos;
        }
    }
}
