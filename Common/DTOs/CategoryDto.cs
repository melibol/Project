using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DTOs
{
    public class CategoryDto
    {


        //public int NewsId { get; set; }
        public int Id { get; set; }
        public string CategoryName { get; set; }

        public List<NewsDto> News { get; set; } 


    }
}
