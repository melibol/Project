using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Abstract
{
    public interface IBaseEntity
    {
    
         bool? IsDeleted { get; set; }
         int Id { get; set; }
    }
}
