using AutoMapper;
using Common.DTOs;
using Core.Services.Abstract;
using Domain.Concrete;
using Domain.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Services.Concrete
{
    public class NewsService : INewsService
    {
        private readonly INewsRepository _newsRepository;
        private readonly IMapper _mapper;
        
        public NewsService(INewsRepository newsRepository, IMapper mapper)
        {
            _newsRepository = newsRepository;
            _mapper = mapper;
        }

        public bool AddNews(NewsDto dto)
        {
            News haber = new News();
            haber.AuthorId = 1;
            haber.CategoryId = 1;

            var eklenecek = _newsRepository.Insert(haber);

            var model = _mapper.Map<NewsDto>(haber);

            if (model!=null)
            {
                return true;
            }

            return false;
        }

        public List<NewsDto> GetAllNews()
        {
            var newsList = _newsRepository.GetAll().AsQueryable().Include(x => x.Author).Include(x => x.Category).ToList();

            var model = _mapper.Map<List<NewsDto>>(newsList);
            return model;

        }

        public bool DeleteNews(int id)
        {
            //id = 22;
            var silinecek = _newsRepository.GetById(id);
            _newsRepository.SoftDelete(silinecek);
            return true;


        }

        public NewsDto GetNewsDetail(int id)
        {
            var newsdetail = _newsRepository.GetById(id);
            var model = _mapper.Map<NewsDto>(newsdetail);

            return model;
        }
    }
}
