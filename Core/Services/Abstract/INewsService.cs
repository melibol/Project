using Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Services.Abstract
{
   public interface INewsService
    {
        List<NewsDto> GetAllNews();
        bool AddNews(NewsDto dto);

        bool DeleteNews(int id);


        NewsDto GetNewsDetail(int id);
       





        //NewsDto DeleteNews();

    }
}
