using PhotoListing.Models.ServiceDTOs.Request;
using PhotoListing.Models.ServiceDTOs.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhotoListing.Services.Interfaces
{
    public interface IPhotoListingService
    {
        Task<IReadOnlyList<Photo>> GetPagedPhotosAsync(PhotoListingRequest plr);
        Task<IReadOnlyList<Photo>> GetPhotosAsync();
    }
}
