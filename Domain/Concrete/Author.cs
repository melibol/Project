using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Concrete
{
    public class Author:BaseEntity,IBaseEntity
    {

        //public Author()
        //{
        //    Id = Id;
        //    Name = Name;
        //    Surname = Surname;
        //}
        
        public string AuthorName { get; set; }

        public string Surname { get; set; }

        public virtual  ICollection<News> News { get; set; }


    }
}
