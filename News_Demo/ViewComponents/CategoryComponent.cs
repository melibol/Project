using Domain.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News_Demo.ViewComponents
{
    public class CategoryComponent:ViewComponent
    {
        //viewcomponentler asenkronik calısır
        //componenti cagırmak için await keywordu kullanılır

        private readonly ICategoryRepository _categoryRepository;
        public CategoryComponent(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public IViewComponentResult Invoke()
        {
            return View(_categoryRepository.GetAll());
        }

    }
}
