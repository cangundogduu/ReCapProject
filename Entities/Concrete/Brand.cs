using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
   public class Brand:ICAr
    {
        public int BrandId { get; set; }
        public string DescriptionName { get; set; }
    }
}
