//Copyright 2017 (c) SmartIT. All rights reserved. By John Kocer
using EfCoreGenericRepository.Models;
using System.Linq;
using System.Threading.Tasks;

namespace EfCoreGenericRepository.DataAccess
{
  public class PostRepository : GenericRepository<Post>, IPostRepository
  {
    public PostRepository(DataContext context) : base(context){}

    public Post Get(int Id)
    {
      return GetAll().FirstOrDefault(b => b.PostId == Id);
    }

    public async Task<Post> GetSingleAsyn(int id)
    {
      return await _context.Set<Post>().FindAsync(id);
    }
  }
}
