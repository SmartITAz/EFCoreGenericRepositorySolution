//Copyright 2017 (c) SmartIT. All rights reserved. By John Kocer
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EfCoreGenericRepository.DataAccess;

namespace Blog.Ui.Controllers
{
  public class BlogsController : Controller
  {
    private readonly IBlogRepository _blogRepository;

    public BlogsController(IBlogRepository blogRepository)
    {
      _blogRepository = blogRepository;
    }

    public async Task<IActionResult> Index()
    {
      return View(await _blogRepository.GetAllAsyn());
    }

    public IActionResult Create()
    {
      return View();
    }

    public IActionResult Details(int id)
    {
      var blogDetail = _blogRepository.Find(b => b.BlogId == id);
      return View(blogDetail);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Title")]EfCoreGenericRepository.Models.Blog blog)
    {
      if (ModelState.IsValid)
      {
        await _blogRepository.AddAsyn(blog);
        await _blogRepository.SaveAsync();
        return RedirectToAction("Index");
      }
      return View(blog);
    }

    public ActionResult Edit(int? id)
    {
      if (id == null)
        return RedirectToAction("Index");

      EfCoreGenericRepository.Models.Blog blog = _blogRepository.Get((int)id);
      return View(blog);

    }

    [HttpPost]
    public ActionResult Edit([Bind("BlogId,CreatedBy,CreatedOn,Title,UpdatedBy,UpdatedOn")]EfCoreGenericRepository.Models.Blog blog)
    {
      if (ModelState.IsValid)
      {
        _blogRepository.Update(blog, blog.BlogId);
        return RedirectToAction("Index");
      }
      return View(blog);
    }

    public ActionResult Delete(int? id)
    {
      if (id == null)
      {
        return RedirectToAction("Index");
      }

      EfCoreGenericRepository.Models.Blog blog = _blogRepository.Get((int)id);
      if (blog == null)
      {
        return RedirectToAction("Index");
      }
      return View(blog);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
      EfCoreGenericRepository.Models.Blog blog = _blogRepository.Get(id);
      _blogRepository.Delete(blog);
      return RedirectToAction("Index");
    }

    protected override void Dispose(bool disposing)
    {
      _blogRepository.Dispose();
      base.Dispose(disposing);
    }
  }
}