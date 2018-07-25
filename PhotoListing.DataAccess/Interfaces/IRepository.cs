using System.Threading.Tasks;

namespace PhotoListing.DataAccess.Interfaces
{
    public interface IRepository<TEntity, in TKey> where TEntity : class
    {
        Task<TEntity> GetAsync(TKey id);
    }
}
