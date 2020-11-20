using Common.DTOs;
using Core.Services.Abstract;
using Core.Services.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News_Demo.Controllers
{
    public class NewsController : Controller
    {
        private readonly ILogger<NewsController> _logger;
        private readonly INewsService _newsService;
        private readonly ICategoryService _categoryService;
        public NewsController(INewsService newsService, ILogger<NewsController> logger, ICategoryService categoryService)
        {
            _newsService = newsService;
            _logger = logger;
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {

            var model = _newsService.GetAllNews();
            return View(model);
        }

        public IActionResult AddNews(NewsDto dto)
        {
            var model = _newsService.AddNews(dto);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteNews(int id)
        {
           _newsService.DeleteNews(id);

            return RedirectToAction("Index");
            
        }

        public IActionResult GetNewsDetail(int id)
        {
            var model = _newsService.GetNewsDetail(id);
            return View(model);
        }

        //public IActionResult GetCategories()
        //{

        //    var model = _categoryService.GetCategories();
        //    return View(model);
        //}
    }
}
