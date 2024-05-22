namespace Talabat.APIs.Errors
{
    public class ApivalidationErrorResponse:ApiResponse
    {
        public IEnumerable<string> Errors { get; set; }
        public ApivalidationErrorResponse():base(400)
        {
            
        }
    }
}
