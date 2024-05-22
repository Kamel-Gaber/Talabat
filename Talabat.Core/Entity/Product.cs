using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Core.Entity
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }

        //ProductBrand relation
        public int ProductBrandId { get; set; } //not allow null

        public ProductBrand ProductBrand { get; set; } //navigation prop


        //
        public int ProductTypeId { get; set; } //not allow null

        public ProductType ProductType { get; set; } //navigation prop





    }
}
