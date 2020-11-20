using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DTOs
{
    public class NewsDto
    {


        public int Id { get; set; }
        //public string AuthorId { get; set; }

        public int CategoryId { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public string Image { get; set; }

        public int ViewCount { get; set; }

        public DateTime CreatedDate { get; set; }

        public AuthorDto Author { get; set; }
        public CategoryDto Category { get; set; }

    }
}
