using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Core.Entities
{
    public class Products : BaseEntity 
    {
        
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public decimal Price { get; set; }

        public int ProductsBrandId { get; set; }

        public ProductsBrand ProductsBrand { get; set; }

        public int ProductsTypeId { get; set; }

        public ProductType ProductType { get; set; }

    }
}
