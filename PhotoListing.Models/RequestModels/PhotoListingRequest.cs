namespace PhotoListing.Models.ServiceDTOs.Request
{
    public class PhotoListingRequest
    {
        public string SortOrder { get; set; }
        public string SearchKey { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
