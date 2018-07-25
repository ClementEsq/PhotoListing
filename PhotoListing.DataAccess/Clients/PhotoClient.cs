using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using PhotoListing.DataAccess.Interfaces;
using PhotoListing.Models.ClientModels;


namespace PhotoListing.DataAccess
{
    public class PhotoClient : Client<Photo>, IClient<Photo>
    {
        public PhotoClient(HttpClient httpClient) : base(httpClient, "/photos")
        {
        }

        public override async Task<IReadOnlyList<Photo>> GetAllAsync()
        {
            IReadOnlyList<Photo> photos = null;
            using (_httpClient)
            {
                HttpResponseMessage response = await _httpClient.GetAsync(_requestUrl);
                using (response)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        photos = await response.Content.ReadAsAsync<IReadOnlyList<Photo>>();
                    }
                }
            }
            return photos;        
        }
    }
}
