//Copyright 2017 (c) SmartIT. All rights reserved. By John Kocer
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using EfCoreGenericRepository.DataAccess;

namespace Blog.Ui.Controllers
{
  [Produces("application/json")]
  [Route("api/Blog")]
  public class BlogsApiController : Controller
  {
    private readonly IBlogRepository _blogRepository;

    public BlogsApiController(IBlogRepository blogRepository)
    {
      _blogRepository = blogRepository;

    }

    [Route("~/api/GetBlogs")]
    [HttpGet]
    public async Task<IEnumerable<EfCoreGenericRepository.Models.Blog>> Index()
    {
      return await _blogRepository.GetAllAsyn();
    }

    [Route("~/api/AddBlog")]
    [HttpPost]
    public async Task<EfCoreGenericRepository.Models.Blog> AddBlog([FromBody]EfCoreGenericRepository.Models.Blog blog)
    {
        await _blogRepository.AddAsyn(blog);
        await _blogRepository.SaveAsync();
      return blog;
    }

    [Route("~/api/UpdateBlog")]
    [HttpPut]
    //public Blog UpdateBlog([FromBody] Blog blog)
    //{
    //  var updated = _blogRepository.Update(blog, blog.BlogId);
    //  return updated;
    //}
    public async Task<EfCoreGenericRepository.Models.Blog> UpdateBlog([FromBody]EfCoreGenericRepository.Models.Blog blog)
    {
      var updated =await  _blogRepository.UpdateAsyn(blog, blog.BlogId);
      return updated;
    }

    [Route("~/api/DeleteBlog/{id}")]
    [HttpDelete]
    public string Delete(int id)
    {
      _blogRepository.Delete(_blogRepository.Get(id));
      return "Employee deleted successfully!";
    }

    protected override void Dispose(bool disposing)
    {
      _blogRepository.Dispose();
      base.Dispose(disposing);
    }
  }
}
