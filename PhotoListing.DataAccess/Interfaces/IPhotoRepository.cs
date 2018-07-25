using PhotoListing.Models.ClientModels;
using PhotoListing.Models.RepositoryDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhotoListing.DataAccess.Interfaces
{
    public interface IPhotoRepository : IRepository<Photo, int>
    {
        Task<IReadOnlyList<Photo>> GetPagedPhotosAsync(PagedPhotoConstraint constraint);
        Task<IReadOnlyList<Photo>> GetPhotosAsync();
    }
}
