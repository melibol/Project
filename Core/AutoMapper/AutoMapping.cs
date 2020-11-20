using AutoMapper;

using Common.DTOs;
using Domain.Concrete;
using System.Collections.Generic;
using System.Text;


namespace Common.AutoMapper
{
   public class AutoMapping:Profile
    {

        public AutoMapping()
        {
            CreateMap<Author, AuthorDto>();/*.ForMember(c=>c.AuthorId,option=>option.Ignore())*/
            CreateMap<AuthorDto, Author>();/*.ForMember(c => c.AuthorId, option => option.Ignore()); */
            CreateMap<Category, CategoryDto>();/*.ForMember(c=>c.CategoryId,opt=>opt.Ignore());*/
            CreateMap<CategoryDto, Category>();/*.ForMember(c => c.CategoryId, opt => opt.Ignore()); */
            CreateMap<News, NewsDto>();/*.ForMember(c => c.NewsId, opt => opt.Ignore()); */
            CreateMap<NewsDto, News>();/*.ForMember(c => c.NewsId, opt => opt.Ignore()); */


            CreateMap<Author, AuthorDto>()
                .ForMember(
                    dest => dest.AuthorName2,opt => opt.MapFrom(src => src.AuthorName)
                );

        }
    }
}
