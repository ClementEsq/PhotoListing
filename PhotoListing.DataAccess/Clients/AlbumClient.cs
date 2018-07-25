using PhotoListing.DataAccess.Interfaces;
using PhotoListing.Models.ClientModels;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PhotoListing.DataAccess
{
    public class AlbumClient : Client<Album>, IClient<Album>
    {
        public AlbumClient(HttpClient httpClient) : base(httpClient, "/albums")
        {
            
        }

        public override async Task<IReadOnlyList<Album>> GetAllAsync()
        {
            IReadOnlyList<Album> albums = null;
            using (_httpClient)
            {
                HttpResponseMessage response = await _httpClient.GetAsync(_requestUrl);
                using (response)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        albums = await response.Content.ReadAsAsync<IReadOnlyList<Album>>();
                    }
                }
            }
            return albums;
        }
    }
}
