using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoListing.Models.RepositoryDTOs
{
    public class PagedPhotoConstraint
    {
        public string SortOrder { get; set; }
        public string SearchKey { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
