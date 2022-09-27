using Microsoft.AspNetCore.Mvc;

namespace ProductApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {

        private readonly ILogger<ProductController> _logger;
        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Product
            {
                Date = DateTime.Now.AddDays(index),
                 id=1,
                  Name="food"
            })
            .ToArray();
        }
        [HttpGet]
        [Route("{id}")]
        public Product GetById(int id)
        {
            return new Product
            {
                Date = DateTime.Now,
                id = id,
                Name = "food"
            }
            ;
        }
        [HttpPost]
        public bool Post(Product product)
        {
            try
            {
                _logger.LogInformation("save product:" + product.Name);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}