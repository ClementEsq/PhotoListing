using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhotoListing.DataAccess.Interfaces
{
    public interface IClient<T>
    {
        Task<IReadOnlyList<T>> GetAllAsync();
    }
}
