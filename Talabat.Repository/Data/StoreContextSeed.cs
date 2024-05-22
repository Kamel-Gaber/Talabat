using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Talabat.Core.Entity;

namespace Talabat.Repository.Data
{
    public class StoreContextSeed
    {

        public static async Task SeedAsync(StoreContext context , ILoggerFactory loggerFactory)
        {
            try
            {
                // ProductBrands Data
                if (!context.ProductBrands.Any())
                {
                    var brandsData = File.ReadAllText("../Talabat.Repository/Data/Dataseed/brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                    foreach (var brand in brands)
                    {
                        context.Set<ProductBrand>().Add(brand);
                    }
                }

                // Producttypes Data
                if (!context.ProductTypes.Any())
                {
                    var typesData = File.ReadAllText("../Talabat.Repository/Data/Dataseed/types.json");
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

                    foreach (var type in types)
                    {
                        context.Set<ProductType>().Add(type);
                    }
                }

                // Products Data
                if (!context.Products.Any())
                {
                    var productsData = File.ReadAllText("../Talabat.Repository/Data/Dataseed/products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                    foreach (var product in products)
                    {
                        context.Set<Product>().Add(product);
                    }
                }

                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var logger =loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex , ex.Message );
            }
        }
    }
}
