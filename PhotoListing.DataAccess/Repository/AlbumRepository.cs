using System.Threading.Tasks;
using PhotoListing.DataAccess.Interfaces;
using PhotoListing.Models.ClientModels;
using System.Linq;
using System.Collections.Generic;

namespace PhotoListing.DataAccess.Repository
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly IClient<Album> _albumClient;

        public AlbumRepository(IClient<Album> albumClient)
        {
            _albumClient = albumClient;
        }

        public async Task<IReadOnlyList<Album>> GetAllAlbumsAsync()
        {
            var albums = await _albumClient.GetAllAsync();
            return albums;
        }
    }
}
