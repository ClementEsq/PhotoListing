using PhotoListing.Models.ClientModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhotoListing.DataAccess.Interfaces
{
    public interface IAlbumRepository 
    {
        Task<IReadOnlyList<Album>> GetAllAlbumsAsync();
    }
}
