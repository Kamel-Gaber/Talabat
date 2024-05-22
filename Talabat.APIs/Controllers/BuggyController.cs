using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.APIs.Errors;
using Talabat.Repository.Data;

namespace Talabat.APIs.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly StoreContext context;

        public BuggyController(StoreContext context)
        {
            this.context = context;
        }


        //1--not found 
        [HttpGet("notfound")]
        public ActionResult GetNotFound()
        {
            var product = context.Products.Find(100);
            if (product == null) return NotFound( new ApiResponse (404));

            return Ok(product);
        }

        //2--servererror
        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
            var product = context.Products.Find(100);
            var productToReturn = product.ToString();

            return Ok(productToReturn);
        }

        //3--badrequest
        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {

            return BadRequest( new ApiResponse(400));
        }

        //4--badrequest with id validation error
        [HttpGet("badrequest/{id}")]
        public ActionResult GetBadRequest(int id)
        {

            return Ok();
        }

    }
}
