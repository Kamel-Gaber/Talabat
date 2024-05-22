using Talabat.Core.Entity;

namespace Talabat.APIs.DTOs
{
    public class ProductsReturnDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }

        //ProductBrand relation
        public int ProductBrandId { get; set; } //not allow null

        public string ProductBrand { get; set; } //navigation prop


        //
        public int ProductTypeId { get; set; } //not allow null

        public string ProductType { get; set; } //navigation prop


    }
}
