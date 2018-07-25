using Moq;
using NUnit.Framework;
using PhotoListing.DataAccess.Interfaces;
using PhotoListing.Models.ClientModels;
using PhotoListing.Services;
using PhotoListing.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhotoListing.Tests
{
    [TestFixture, Category("Unit test")]
    public class AlbumServiceTests
    {
        private IAlbumService _albumService;
        private Mock<IAlbumRepository> _albumRepositoryMock;

        [SetUp]
        public void SetUp()
        {
            _albumRepositoryMock = new Mock<IAlbumRepository>();
            _albumService = new AlbumService(_albumRepositoryMock.Object);
        }

        [Test]
        public async Task GetAlbumsAsync_EnsureListOfAlbumsFromRepositoryIsReturnedFromService()
        {
            var expectedAlbums = new List<Album>()
            {
                new Album()
                {
                    Id = 1,
                    Title = "TestTitle",
                    UserId = 1
                }
            };

            _albumRepositoryMock.Setup(ap => ap.GetAllAlbumsAsync()).ReturnsAsync(expectedAlbums);

            var actualAlbums = await _albumService.GetAlbumsAsync();

            Assert.AreSame(expectedAlbums, actualAlbums);
        }
    }
}
