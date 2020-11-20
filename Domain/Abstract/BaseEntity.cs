using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Abstract
{
   public class BaseEntity
    {
       
        public bool? IsDeleted { get; set; }
        public int Id { get; set; }


    }
}
