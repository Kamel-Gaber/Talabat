using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.APIs.DTOs;
using Talabat.APIs.Errors;
using Talabat.APIs.Helpers;
using Talabat.Core.Entity;
using Talabat.Core.Repositories;
using Talabat.Core.Specification;

namespace Talabat.APIs.Controllers
{
    
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productsRepo;
        private readonly IGenericRepository<ProductBrand> _barndsRepo;
        private readonly IGenericRepository<ProductType> _typeRepo;
        private readonly IMapper _mapper;

        #region  ProductsController ctor
        public ProductsController(IGenericRepository<Product> productsRepo ,
            IGenericRepository<ProductBrand>barndsRepo,
            IGenericRepository<ProductType>typeRepo,
            IMapper mapper)
        {
            _productsRepo = productsRepo;
            _barndsRepo = barndsRepo;
            _typeRepo = typeRepo;
            _mapper = mapper;
        }

        #endregion

        #region products  without spec
        //without spec
        [HttpGet] //GET:api/Products

        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _productsRepo.GetAllAsync();

            return Ok(products);
        }

        [HttpGet("{id}")]//GET:api/Products/12
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var porduct = await _productsRepo.GetByIdAsync(id);
            if (porduct == null) return NotFound(new ApiResponse(404));

            return Ok(porduct);
        }

        #endregion

        #region products with spec
        //with  spec ,sort , filtering ,pagination
        [HttpGet("withspec")] //GET:api/Products

        public async Task<ActionResult<Pagination<ProductsReturnDto>>> GetAllProductWithSpec( [FromQuery] ProuductsSpecParams prouductsParams)
        {
            var spec = new ProductWithBrandAndTypeSpecification(prouductsParams);
            var products = await _productsRepo.GetAllWithSpecAsync(spec);


            var Data = _mapper.Map<IEnumerable<Product>,IEnumerable<ProductsReturnDto>>(products) ;
            var countSpec = new ProductWithFiltersForCountSpecification(prouductsParams);
            var Count = await _productsRepo.GetCountAsync(countSpec);

            return Ok(new Pagination<ProductsReturnDto>(prouductsParams.PageIndex,prouductsParams.PageSize,Count,Data));
        }

        [HttpGet("withspec/{id}")]//GET:api/Products/12 
        public async Task<ActionResult<Product>> GetProductByIdwithspec(int id)
        {
            var spec = new ProductWithBrandAndTypeSpecification(id);

            var porduct = await _productsRepo.GetByIdWithSpecAsync(spec);

            return Ok(_mapper.Map<Product, ProductsReturnDto>(porduct));
        }
        #endregion

        #region  brands

        [HttpGet("brands")] //GET:api/Products/brands

        public async Task<ActionResult<IEnumerable<ProductBrand>>> GetBrands()
        {
            var brands = await _barndsRepo.GetAllAsync();

            return Ok(brands);
        }
        #endregion

        #region  types

        [HttpGet("types")] //GET:api/Products/types

        public async Task<ActionResult<IEnumerable<ProductBrand>>> GetTypes()
        {
            var types = await _typeRepo.GetAllAsync();

            return Ok(types);
        }
        #endregion

    }
}
