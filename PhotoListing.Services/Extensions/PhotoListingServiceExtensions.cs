using PhotoListing.Models.ClientModels;
using PhotoListing.Models.RepositoryDTOs;
using PhotoListing.Models.ServiceDTOs.Request;
using PhotoListing.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace PhotoListing.Services.Extensions
{
    public static class PhotoListingServiceExtensions
    {
        private static string GetAlbumName(IReadOnlyList<Album> albums, int albumId)
        {
            var album = albums.FirstOrDefault(a => a.Id == albumId);
            return album?.Title;
        }

        private static Models.ServiceDTOs.Response.Photo CreateAPhotoItem(Photo photo, int index)
        {
            return new Models.ServiceDTOs.Response.Photo()
            {
                Id = index,
                PhotoTitle = photo?.Title,
                Thumbnail = photo?.ThumbnailUrl,
                LinkUrl = photo?.Url
            };
        }

        public static PagedPhotoConstraint CreatePagedPhotoRepositoryConstraint(this IPhotoListingService photoListingService,  PhotoListingRequest plr)
        {
            return new PagedPhotoConstraint()
            {
                Page = plr.Page,
                PageSize = plr.PageSize,
                SortOrder = plr.SortOrder,
                SearchKey = plr.SearchKey
            };
        }

        public static IReadOnlyList<Models.ServiceDTOs.Response.Photo> CreatePagedPhotoResponse(this IPhotoListingService photoListingService, IReadOnlyList<Album> albums, IReadOnlyList<Photo> photos)
        {
            var responsePhotos = new List<Models.ServiceDTOs.Response.Photo>();

            if (photos != null)
            {
                for (var i = 0; i < photos.Count; ++i)
                {
                    var photo = CreateAPhotoItem(photos[i], i+1);
                    photo.AlbumName = GetAlbumName(albums, photos[i].AlbumId);
                    responsePhotos.Add(photo);
                }
            }

            return responsePhotos;
        }
    }
}
