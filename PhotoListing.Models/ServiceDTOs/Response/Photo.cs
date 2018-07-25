namespace PhotoListing.Models.ServiceDTOs.Response
{
    public class Photo
    {
        public int Id { get; set; }
        public string PhotoTitle { get; set; }
        public string AlbumName { get; set; }
        public string Thumbnail { get; set; }
        public string LinkUrl { get; set; }
    }
}
