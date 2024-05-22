using AutoMapper;
using Talabat.APIs.DTOs;
using Talabat.Core.Entity;

namespace Talabat.APIs.Helpers
{
    public class ProductPictureUrlResolver : IValueResolver<Product, ProductsReturnDto, string>
    {
        public IConfiguration Configuration { get; }
        public ProductPictureUrlResolver(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public string Resolve(Product source, ProductsReturnDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
                return $"{Configuration["BaseApiUrl"]}{source.PictureUrl}";

            return null;
              
           
        }
    }
}
