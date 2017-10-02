//Copyright 2017 (c) SmartIT. All rights reserved. By John Kocer
using EfCoreGenericRepository.Models;

namespace EfCoreGenericRepository.DataAccess
{
  public   interface IPostRepository : IGenericRepository<Post>
  {
    // If you need to customize your entity actions you can put here  
    Post Get(int id);
  }
}
