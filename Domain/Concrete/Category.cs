using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Concrete
{
    public class Category:BaseEntity, IBaseEntity
    {

        //public Category()
        //{
        //    Id = Id;
        //    CategoryName = CategoryName;

        //}
       
        public string CategoryName{ get; set; }

        public virtual ICollection<News> News { get; set; }







    }
}
