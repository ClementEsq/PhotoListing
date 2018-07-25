using PhotoListing.DataAccess.Interfaces;
using PhotoListing.Models.ClientModels;
using PhotoListing.Services.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PhotoListing.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository _albumRepository;

        public AlbumService(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        public async Task<IReadOnlyList<Album>> GetAlbumsAsync()
        {
            var albums = await _albumRepository.GetAllAlbumsAsync();
            return albums;
        }
    }
}
