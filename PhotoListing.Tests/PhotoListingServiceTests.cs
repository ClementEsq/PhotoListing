using Moq;
using NUnit.Framework;
using PhotoListing.DataAccess.Interfaces;
using PhotoListing.Models.ClientModels;
using PhotoListing.Services;
using PhotoListing.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoListing.Tests
{
    [TestFixture, Category("Unit test")]
    public class PhotoListingServiceTests
    {
        private IPhotoListingService _photoListingService;
        private Mock<IAlbumService> _albumServiceMock;
        private Mock<IPhotoRepository> _photoRepositoryMock;

        private List<Photo> ExpectedPhotos
        {
            get
            {
                return new List<Photo>()
                {
                    new Photo()
                    {
                        Id = 1,
                        AlbumId = 1
                    }
                };
            }
        }

        private Models.ServiceDTOs.Response.Photo ExpectedPhoto
        {
            get
            {
                return new Models.ServiceDTOs.Response.Photo()
                {
                    Id = 1,
                    AlbumName = "AlbumName"
                };
            }
        }

        private List<Album> ExpectedAlbums
        {
            get
            {
                return new List<Album>()
                {
                    new Album()
                    {
                        Id = 1,
                        Title = "AlbumName"
                    }
                };
            }
        }

        [SetUp]
        public void SetUp()
        {
            _albumServiceMock = new Mock<IAlbumService>();
            _photoRepositoryMock = new Mock<IPhotoRepository>();
            _photoListingService = new PhotoListingService(_albumServiceMock.Object, _photoRepositoryMock.Object);
        }

        [Test]
        public void GetPhotosAsync_EnsureArgumentNullExceptionIsThrownIfAlbumListIsNull()
        {
            IReadOnlyList<Album> expectedAlbums = null;

            _photoRepositoryMock.Setup(pr => pr.GetPhotosAsync()).ReturnsAsync(ExpectedPhotos);
            _albumServiceMock.Setup(a => a.GetAlbumsAsync()).ReturnsAsync(expectedAlbums);

            Assert.ThrowsAsync<ArgumentNullException>(() => _photoListingService.GetPhotosAsync());
        }

        [Test]
        public void GetPhotosAsync_EnsureExceptionIsNotThrownIfPhotoListAndAlbumListHaveValues()
        {
            _photoRepositoryMock.Setup(pr => pr.GetPhotosAsync()).ReturnsAsync(ExpectedPhotos);
            _albumServiceMock.Setup(a => a.GetAlbumsAsync()).ReturnsAsync(ExpectedAlbums);

            Assert.DoesNotThrowAsync(() => _photoListingService.GetPhotosAsync());
        }

        [Test]
        public async Task GetAlbumsAsync_EnsureListOfPhotosReturnedIsPhotoObjectWithAlbumDetails()
        {
            _photoRepositoryMock.Setup(pr => pr.GetPhotosAsync()).ReturnsAsync(ExpectedPhotos);
            _albumServiceMock.Setup(a => a.GetAlbumsAsync()).ReturnsAsync(ExpectedAlbums);

            var actualPhotos = await _photoListingService.GetPhotosAsync();
            var actualPhoto = actualPhotos?.FirstOrDefault();

            Assert.AreSame(ExpectedPhoto.AlbumName, actualPhoto.AlbumName);
        }
    }
}
