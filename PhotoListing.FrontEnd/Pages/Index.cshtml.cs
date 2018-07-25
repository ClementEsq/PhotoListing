using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PhotoListing.Models.ServiceDTOs.Request;
using PhotoListing.Models.ServiceDTOs.Response;
using PhotoListing.Services.Interfaces;

namespace PhotoListing.FrontEnd.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IPhotoListingService _photoListingService;

        public IReadOnlyList<Photo> Photos { get; set; }

        public IndexModel(IPhotoListingService photoListingService)
        {
            _photoListingService = photoListingService;
        }

        public async Task OnGetAsync()
        {
            Photos = await _photoListingService.GetPhotosAsync();
        }
    }
}
