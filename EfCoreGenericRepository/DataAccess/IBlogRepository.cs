using EfCoreGenericRepository.Models;

namespace EfCoreGenericRepository.DataAccess
{
  public interface IBlogRepository : IGenericRepository<Blog>
    {
        // If you need to customize your entity actions you can put here  
        Blog Get(int blogId);
    }
}
