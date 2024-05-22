using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entity;

namespace Talabat.Core.Specification
{
    public class ProductWithFiltersForCountSpecification:BaseSpecification<Product>
    {
        public ProductWithFiltersForCountSpecification(ProuductsSpecParams prouductsParams)
            :base(P=>
                        (string.IsNullOrEmpty(prouductsParams.Search) || P.Name.ToLower().Contains(prouductsParams.Search))&&
                        (!prouductsParams.brandId.HasValue || P.ProductBrandId == prouductsParams.brandId) &&
                        (!prouductsParams.typeId.HasValue || P.ProductTypeId == prouductsParams.typeId))
        {
            
        }

    }
}
