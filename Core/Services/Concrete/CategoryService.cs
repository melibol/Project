using AutoMapper;
using Common.DTOs;
using Core.Services.Abstract;
using Domain.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Concrete
{
    public class CategoryService : ICategoryService
    {
        //private readonly ICategoryRepository _categoryRepository;
        //private readonly IMapper _mapper;
     


        //public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        //{
        //    _mapper = mapper;
        //    _categoryRepository = categoryRepository;
            
        //}
        //public IEnumerable<CategoryDto> GetCategories()
        //{
        //    var categories = _categoryRepository.GetAll();
        //    var model = _mapper.Map<IEnumerable<CategoryDto>>(categories);

        //    return model;
        //}
    }
}
