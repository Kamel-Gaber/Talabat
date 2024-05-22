using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entity;

namespace Talabat.Core.Specification
{
    public class ProductWithBrandAndTypeSpecification:BaseSpecification<Product>
    {
        public ProductWithBrandAndTypeSpecification(ProuductsSpecParams prouductsParams  )
            :base (P=>
                        (string.IsNullOrEmpty(prouductsParams.Search) || P.Name.ToLower().Contains(prouductsParams.Search))&&
                        (!prouductsParams.brandId.HasValue || P.ProductBrandId==prouductsParams.brandId)&&
                        (!prouductsParams.typeId.HasValue  || P.ProductTypeId== prouductsParams.typeId))
        {
            Include.Add(p => p.ProductBrand);
            Include.Add(p => p.ProductType);


            ApplyPagination(prouductsParams.PageSize * (prouductsParams.PageIndex-1), prouductsParams.PageSize);

            if(!string.IsNullOrEmpty(prouductsParams.sort))
            {
                switch(prouductsParams.sort)
                {
                    case "priceAsc":
                        AddOrderBy(p=>p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(p=>p.Price);
                        break;
                    default:
                        AddOrderBy(p=>p.Name);
                        break;

                }
            }


        }

        public ProductWithBrandAndTypeSpecification(int id):base(p=>p.Id==id)
        {
            Include.Add(p => p.ProductBrand);
            Include.Add(p => p.ProductType);


        }


    }
}
