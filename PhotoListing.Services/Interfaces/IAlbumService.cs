using PhotoListing.Models.ClientModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhotoListing.Services.Interfaces
{
    public interface IAlbumService
    {
        Task<IReadOnlyList<Album>> GetAlbumsAsync();
    }
}
