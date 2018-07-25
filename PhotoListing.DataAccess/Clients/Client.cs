using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PhotoListing.DataAccess
{
    public abstract class Client<T>
    {
        protected readonly HttpClient _httpClient;

        protected string _requestUrl { get; set; }

        public Client (HttpClient httpClient, string requestUrl)
        {
            _httpClient = httpClient;
            _requestUrl = requestUrl;
        }

        public abstract Task<IReadOnlyList<T>> GetAllAsync();

    }
}
