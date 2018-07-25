using PhotoListing.DataAccess.Interfaces;
using PhotoListing.DataAccess.Repository;
using PhotoListing.Models.ClientModels;
using System.Collections.Generic;
using System.Linq;

namespace PhotoListing.DataAccess.Extensions
{
    public static class PhotoRepositoryExtensions
    {
        public static IReadOnlyList<Photo> GetPageFromPhotoList(this IPhotoRepository photoRepository, IReadOnlyList<Photo> photos, int page, int pageSize)
        {
            return photos.Skip(page * pageSize).Take(pageSize).ToList();
        }

        public static IReadOnlyList<Photo> SearchPhotoList(this IPhotoRepository photoRepository, IReadOnlyList<Photo> photos, string key)
        {
            photos = photos.Where(p => p.Title.Contains(key))?.ToList();
            return photos;
        }
    }
}
