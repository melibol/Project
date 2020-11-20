using Common.DTOs;
using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Concrete
{
  public  class News: BaseEntity, IBaseEntity
    {

        //public News()
        //{
        //    Id = Id;
        //    AuthorId = AuthorId;
        //    CategoryId = CategoryId;
        //    Title = Title;
        //    Description = Description;
        //    Content = Content;
        //    Image = Content;
        //    Image = Image;
        //    ViewCount = ViewCount;
        //    CreatedDate = DateTime.Now;

        //}
      
        public int AuthorId { get; set; }

        public int CategoryId { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public string Image { get; set; }

        public int? ViewCount { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual Author Author { get; set; }

        public virtual Category Category { get; set; }

    }
}
